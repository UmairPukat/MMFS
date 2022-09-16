using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MMFS_Common.EmailSendProcess;
using MMFS_Context;
using MMFS_Models.AccountDto;
using MMFS_Models.EmailSendDto;
using MMFS_POCO.UserManagement;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _Configuration;

        public AuthController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _Configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]  LoginUserDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
                if (user != null && result.Succeeded)
                {

                    var userRoles = await _userManager.GetRolesAsync(user);
                    var roleIds = _roleManager.Roles.Where(r => userRoles.AsEnumerable().Contains(r.Name)).Select(r => r.Id).ToList();
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:Secret"]));
                    var token = new JwtSecurityToken(
                        issuer: _Configuration["JWT:ValidIssuer"],
                        audience: _Configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        role = userRoles.FirstOrDefault().ToString(),
                        roleId = roleIds.FirstOrDefault().ToString(),
                        userName = user.Email == null ? user.UserName : user.Email,
                        userId = user.Id,
                        message = "Login Successfully"
                    }); ; ;
                }
                return Unauthorized(new { message = "UserName and Password are Incorrect" });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Something Went Wrong",
                    Error = ex
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.UserName);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });

                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    FullName = model.FullName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                if (model.RoleId != null)
                {
                    var roleName = await _roleManager.FindByIdAsync(model.RoleId);
                    await _userManager.AddToRoleAsync(user, roleName.Name);
                }

                return Ok(new { Status = "Success", Message = "User created successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Something Went Wrong",
                    Error = ex
                });
            }
        }

    }
}
