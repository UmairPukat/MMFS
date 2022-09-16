using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMFS_Models.AccountDto;
using MMFS_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMFS_WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly SecurityService _securityService;
        public SecurityController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet]
        public IActionResult getUserPermission(string RoleId)
        {
            try
            {
                var result = _securityService.GetPermissions(RoleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Something Went Wrong",
                    Error = ex
                });
            }
        }

        [HttpGet]
        public IActionResult getAccessingComponent(string roleId)
        {
            try
            {
                var result = _securityService.GetAccessingComponent(roleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Something Went Wrong",
                    Error = ex
                });
            }
        }

        [HttpGet]
        public IActionResult getPermissionByRoleId(string RoleId)
        {
            try
            {
                var result = _securityService.getPermissionByRoleId(RoleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Something Went Wrong",
                    Error = ex
                });
            }
        }

        [HttpPost]
        public IActionResult UpdatePermission(List<PermissionAssignDto> model)
        {
            try
            {
                _securityService.UpdatePermissionByUserId(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = "Something Went Wrong",
                    Error = ex
                });
            }
        }
    }
}
