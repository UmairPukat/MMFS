using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MMFS_Context;
using MMFS_Models.AccountDto;
using MMFS_POCO;
using MMFS_POCO.UserManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Services
{
    public class UserService
    {
        private readonly IConfiguration _Configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly _DbContext _DbContext;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UserService(IConfiguration Configuration,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            _DbContext DbContext)
        {
            _Configuration = Configuration;
            _userManager = userManager;
            _DbContext = DbContext;
            _roleManager = roleManager;
        }

        public async Task<bool> FilesUploadAsync(IFormFile file, string UserId)
        {
            var FilePath = _Configuration.GetSection("FilePath").Value;
            var ImageUploadPath = _Configuration.GetSection("ImageUploadPath").Value;
            String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var folderName = FilePath + ImageUploadPath;

            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, timeStamp + fileName);
                var dbPath = Path.Combine(folderName, timeStamp + fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var User = await _userManager.FindByIdAsync(UserId);
                var path = (User.Image == null) ? null : Path.Combine(FilePath + User.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                User.Image = ImageUploadPath + timeStamp + fileName;
                _DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IdentityResult> AddRole(ApplicationRole model)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(model.Name))
                {
                   var data = await _roleManager.CreateAsync(model);
                   return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityResult> UpdateRole(RoleDto model)
        {
            try
            {
                ApplicationRole role = new ApplicationRole()
                {
                    Name = model.RoleName,
                    NormalizedName = model.RoleName.ToUpper()
                };
                var result = await _roleManager.UpdateAsync(role);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RoleDto> getAssignedRole(string roleId)
        {
            try
            {
                var result = (from user in _DbContext.Users
                              join userRoles in _DbContext.UserRoles
                              on user.Id equals userRoles.UserId
                              join roles in _DbContext.Roles
                              on userRoles.RoleId equals roles.Id
                              where(roleId == roles.Id)
                              select new RoleDto
                              {
                                  UserId = user.Id,
                                  UserName = user.FullName,
                                  Email = user.Email,
                                  RoleId = roles.Id,
                                  RoleName = roles.Name,
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public void FirstTimelogin(string userName)
        {
            FirstTimeLogin first = new FirstTimeLogin()
            {
                Email = userName,
                //CreatedBy = "",
                CreatedDateTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
            };
            _DbContext.FirstTimeLogin.Add(first);
            _DbContext.SaveChanges();
        }

        public List<UserRoleDto> GetAllUserRole()
        {
            var result = (from user in _DbContext.Users
                          join userRoles in _DbContext.UserRoles
                          on user.Id equals userRoles.UserId
                          join roles in _DbContext.Roles
                          on userRoles.RoleId equals roles.Id
                          select new UserRoleDto
                          {
                              UserId = user.Id,
                              UserName = user.FullName,
                              Email = user.Email,
                              RoleId = roles.Id,
                              RoleName = roles.Name,
                          }).ToList();
            return result;
        }

        public IQueryable<FirstTimeLogin> GetFirstTimelogin()
        {
            return _DbContext.FirstTimeLogin;
        }
    }
}
