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
using MMFS_Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _Configuration;
        private readonly MailService _mailService;
        private readonly _DbContext _DbContext;
        private readonly UserService _userService;

        public ApplicationController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager,
            MailService mailService,
            _DbContext DbContext,
            UserService userService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _Configuration = configuration;
            _signInManager = signInManager;
            _mailService = mailService;
            _DbContext = DbContext;
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] RegisterUserDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User Not exists!" });
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.FullName = model.FullName;

                var userData = await _userManager.FindByNameAsync(model.UserName);
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                if (model.RoleId != null)
                {
                    var roleName = await _roleManager.FindByIdAsync(model.RoleId);
                    await _userManager.AddToRoleAsync(user, roleName.Name);
                }


                return Ok(new { Status = "Success", Message = "User Updated successfully!" });
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
        public async Task<IActionResult> ResetUserPassword([FromBody] ResetPasswordDto model)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(model.UserId);
                var token = await _userManager.GeneratePasswordResetTokenAsync(User);
                var result = await _userManager.ResetPasswordAsync(User, token, model.Password);

                return Ok(new { Status = "Success", Message = "Password Reset successfully!" });
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

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                var result = _userManager.Users;
                return Ok(result);
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

        [HttpGet]
        public IActionResult GetAllUserRole()
        {
            try
            {
                var result = _userService.GetAllUserRole();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllRole()
        {
            try
            {
                var data = _DbContext.Roles;
                var result = new SelectList(data, "Id", "Name");
                return Ok(result);
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

        [HttpGet]
        public async Task<IActionResult> SendVarificationCode(string UserName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(UserName);
                    if (user == null)
                    {
                        return BadRequest(new { message = "Something Went Wrong" });
                    }
                    var BaseURL = _Configuration.GetSection("BaseURL").Value;
                    var FullUrl = BaseURL + "forgetPassword";
                    Random random = new Random();
                    var code = random.Next(100000, 999999);
                    MailRequest request = new MailRequest()
                    {
                        ToEmail = "jawadgul2017@gmail.com",
                        Subject = "Testing",
                        Body = "<h5>Hi " + UserName + ", </h5>" +
                        "<p> Please click below link and reset your password by varification code with in 10 minutes.</p>" +
                        "<p> Reset Url: <a href = " + FullUrl + "> " + FullUrl + " </a> </p> <p>" +
                        " Varification Code: " + code + " </p> "
                    };
                    await _mailService.SendEmailAsync(request);
                    var Person = _userManager.Users.FirstOrDefault(x => x.Id == user.Id);
                    Person.VarificationCode = code;
                    Person.CodeValidDate = DateTime.Now;
                    _DbContext.SaveChanges();
                    return Ok(new { message = "Varification code send successfully on your Email." });

                }
                return Ok(new
                {
                    message = "Something Went Wrong"
                });

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
        public async Task<IActionResult> forgetPassword(ResetPasswordDto model)
        {
            try
            {
                var User = _DbContext.Users.Where(x => x.VarificationCode == model.VarificationCode).FirstOrDefault();
                if (User == null)
                {
                    return BadRequest(new
                    {
                        message = "Varification Code is expired"
                    });
                }
                var TotalMinutes = (DateTime.Now - User.CodeValidDate).TotalMinutes;
                if (User.VarificationCode == model.VarificationCode && TotalMinutes < 10)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(User);
                    var result = await _userManager.ResetPasswordAsync(User, token, model.Password);
                    User.LastModifiedBy = model.UserId;
                    User.CodeValidDate = DateTime.Now;
                    User.VarificationCode = 0;
                    _DbContext.SaveChanges();
                }
                else
                {
                    return BadRequest(new
                    {
                        message = "Varification Code is expired"
                    });
                }
                return Ok(new
                {
                    Message = "Password Reset successfully!"
                });

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
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(model.UserId);
                if (User == null)
                {
                    return NotFound(new { message = "User not found" });
                }
                var res = await _userManager.ChangePasswordAsync(User, model.CurrentPassword, model.Password);
                if (res.Succeeded)
                {
                    User.LastModifiedBy = model.UserId;
                    User.LastModifiedDateTime = DateTime.Now;
                    _DbContext.SaveChanges();
                    var BaseURL = _Configuration.GetSection("BaseURL").Value;
                    MailRequest request = new MailRequest()
                    {
                        ToEmail = "jawadgul2017@gmail.com",
                        Subject = "Your Account Password is Changed",
                        Body = "<h5>Hi " + User.UserName + ", </h5>" +
                        "<p>Your account password is changed now.</p>" +
                        "<p>You can login to your account using your new password. </p> " +
                        "<p> Login Url: <a href = " + BaseURL + "> " + BaseURL + " </a> </p>"+
                        "<p>DO NOT reply to this email.This email is system generated.<br>" +
                        "PukatDigital Team Automated Email Sender Service.</p> "
                    };
                    await _mailService.SendEmailAsync(request);

                }
                else
                {
                    return BadRequest(new
                    {
                        message = "Current Password not Match"
                    });
                }
                return Ok(new
                {
                    Message = "Password Reset successfully!"
                });

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
        public IActionResult UserImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var UserId = JsonConvert.DeserializeObject<string>(Request.Form["UserId"]);
                var result = _userService.FilesUploadAsync(file, UserId).Result;
                if(result == true)
                return Ok(new { message = "Image Updated Successfully" });

                return BadRequest(new { message = "Something Went Wrong" });
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

        [HttpGet]
        public async Task<IActionResult> getUserByIdAsync(string UserId)
        {
            try
            {
                var result = await _userManager.FindByIdAsync(UserId);
                return Ok(result);
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
        public async Task<IActionResult> AddRole([FromBody] RoleDto role)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(role.RoleName))
                {
                    var model = new ApplicationRole
                    {
                        Name = role.RoleName,
                    };
                    var result = await _roleManager.CreateAsync(model);
                    if (result.Succeeded)
                    {
                        return Ok(new { message = "New Role Created Successfully" });
                    }
                    else
                    {
                        return BadRequest(new { message = "Something Went Wrong" });
                    }
                }
                else
                {
                    return BadRequest(new { message = "Role " + role.RoleName + " is Already Exist" });
                }
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
        public async Task<IActionResult> UpdateRole([FromBody] RoleDto model)
        {
            try
            {
                var result = await _roleManager.FindByIdAsync(model.RoleId.ToString());
                if (result == null)
                {
                    return NotFound(new { message = "Role with the given id Not Found" });
                }
                else
                {
                    result.Name = model.RoleName;
                    var updated = await _roleManager.UpdateAsync(result);
                    if (updated.Succeeded)
                    {
                        return Ok(new { message = "Role Updated Successfully" });
                    }
                    else
                    {
                        return BadRequest(new { message = "Something Went Wrong" });
                    }
                }
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

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string RoleId)
        {
            try
            {
                var result = await _roleManager.FindByIdAsync(RoleId.ToString());
                if (result == null)
                {
                    return NotFound(new { message = "Role with the given id Not Found" });
                }
                else
                {
                    var updated = await _roleManager.DeleteAsync(result);
                    if (updated.Succeeded)
                    {
                        return Ok(new { message = "Role Deleted Successfully" });
                    }
                    else
                    {
                        return BadRequest(new { message = "Something Went Wrong" });
                    }
                }
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Something Went Wrong" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> getAssignedRole(string RoleId)
        {
            try
            {
                var result = _userService.getAssignedRole(RoleId);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Something Went Wrong" });
            }
        }

        [HttpGet]
        public IActionResult AddFirstTimeLogin(string UserName)
        {
            try
            {
                _userService.FirstTimelogin(UserName);
                return Ok(new { message = "First Time Login Successfully"});
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Something Went Wrong",
                    error = ex
                });
            }
        }
        [HttpGet]
        public IActionResult GetFirstTimeLogin(string UserName)
        {
            try
            {
                var result = _userService.GetFirstTimelogin();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Something Went Wrong",
                    error = ex
                });
            }
        }
    }
    

}


