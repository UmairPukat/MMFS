using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MMFS_Context;
using MMFS_Models.UserProfileDto;
using MMFS_POCO;
using MMFS_POCO.UserManagement;
using MMFS_POCO.UserProfile;
using MMFS_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMFS_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserProfileService _userProfileService;
        private readonly _DbContext _DbContext;
        public UserProfileController(UserProfileService userProfileService,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            _DbContext DbContext)
        {
            _userProfileService = userProfileService;
            _userManager = userManager;
            _roleManager = roleManager;
            _DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetPaymentMethod()
        {
            try
            {
                var data = _userProfileService.GetPaymentMethod();
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
        public IActionResult GetRaces()
        {
            try
            {
                var data = _userProfileService.GetRaces();
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
        public IActionResult GetReligion()
        {
            try
            {
                var data = _userProfileService.GetReligion();
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
        public IActionResult GetAllCity()
        {
            try
            {
                var data = _userProfileService.GetAllCity();
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
        public IActionResult GetAllState()
        {
            try
            {
                var data = _userProfileService.GetAllState();
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

        [HttpPost]
        public async Task<IActionResult> AddUserPersonalInfo(PersonalProfile model)
        {
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.UserName);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });

                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.EmailAddress,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    FullName = model.FullName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                }
                else
                {
                    if (model.UserTypeId != null)
                    {
                        var roleName = await _roleManager.FindByIdAsync(model.UserTypeId);
                        await _userManager.AddToRoleAsync(user, roleName.Name);
                    }
                   _userProfileService.AddPersonalProfileAsync(model, user.Id);
                }
                return Ok(new { 
                    message = "Personal Profile added Successfully",
                    UserId = user.Id
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
        public IActionResult UpdateUserPersonalInfo(PersonalProfile model)
        {
            try
            {
                _userProfileService.UpdatePersonalProfile(model);
                return Ok(new
                {
                    message = "Personal Profile Updated Successfully",
                    UserId = model.UserId
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
        public IActionResult AddUserBusinessProfile(BusinessProfile model)
        {
            try
            {
                _userProfileService.AddUserBusinessProfile(model);
                return Ok(new
                {
                    message = "Business Profile added Successfully",
                    UserId = model.UserId
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
        public IActionResult UpdateUserBusinessProfile(BusinessProfile model)
        {
            try
            {
                _userProfileService.UpdateUserBusinessProfile(model);
                return Ok(new
                {
                    message = "Business Profile Updated Successfully",
                    UserId = model.UserId
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
        public IActionResult AddUserEmergencyProfile(UserEmergencyProfile model)
        {
            try
            {
                _userProfileService.AddUserEmergencyProfile(model);
                return Ok(new
                {
                    message = "Emergency & Medical Profile added Successfully",
                    UserId = model.UserId
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
        public IActionResult UpdateUserEmergencyProfile(UserEmergencyProfile model)
        {
            try
            {
                _userProfileService.UpdateUserEmergencyProfile(model);
                return Ok(new
                {
                    message = "Emergency & Medical Profile Updated Successfully",
                    UserId = model.UserId
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
        public IActionResult AddUserChequeProfile(UserChequeProfile model)
        {
            try
            {
                _userProfileService.AddUserChequeProfile(model);
                return Ok(new
                {
                    message = "Cheque Information Profile added Successfully",
                    UserId = model.UserId
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
        public IActionResult UpdateUserChequeProfile(UserChequeProfile model)
        {
            try
            {
                _userProfileService.UpdateUserChequeProfile(model);
                return Ok(new
                {
                    message = "Cheque Information Profile Updated Successfully",
                    UserId = model.UserId
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
        [HttpGet]
        public IActionResult getFullProfileOfUser(string UserId)
        {
            try
            {
                var result = _userProfileService.getFullProfileOfUser(UserId);
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
        public IActionResult GetAllUserProfile()
        {
            try
            {
                var result = _userProfileService.getUserProfile();
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
        public IActionResult DeleteUserById(string UserId)
        {
            try
            {
                var result = _userProfileService.DeleteUserById(UserId);
                if (result == false)
                {
                    return NotFound(new { message = "User with the given id Not Found" });
                }
                return Ok(new { message = "User Deleted Successfully" });
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
