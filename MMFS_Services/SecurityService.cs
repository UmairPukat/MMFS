using Microsoft.EntityFrameworkCore;
using MMFS_Context;
using MMFS_Models.AccountDto;
using MMFS_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Services
{
    public class SecurityService
    {
        private readonly _DbContext _DbContext;
        public SecurityService(_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public List<PermissionDto> GetPermissions(string UserId)
        {
            var result = (from p in _DbContext.Permissions
                          join app in _DbContext.Roles
                          on p.RoleId equals app.Id
                          join a in _DbContext.AccessingComponents
                          on p.AccessingCompId equals a.Id
                          where (p.RoleId == UserId)
                          select new PermissionDto
                          {
                              RoleId = p.RoleId,
                              Name = a.Name,
                              Url = a.URL,
                              Icons = a.Icons

                          }).ToList();
            return result;
        }

        public ICollection<AccessingComponentDto> GetAccessingComponent(string roleId)
        {
            var result = (from p in _DbContext.Permissions
                          join a in _DbContext.AccessingComponents
                          on p.AccessingCompId equals a.Id
                          where (p.RoleId == roleId)
                          select new AccessingComponentDto
                          {
                             Name = a.Name,
                             Status = p.Status
                          }).ToList();
            return result;
        }

        public IQueryable<Permission> getPermissionByRoleId(string RoleId)
        {
            return _DbContext.Permissions.Where(x => x.RoleId == RoleId);
        }

        public void UpdatePermissionByUserId(List<PermissionAssignDto> model)
        {
            //List<Permission> per = new List<Permission>();
            //List<Permission> per1 = new List<Permission>();

            //foreach (var item in model)
            //{
            //    if(item.id == null)
            //    {
            //        Permission permission = new Permission()
            //        {
            //            UserId = item.userId,
            //            AccessingCompId = item.accessingCompId
            //        };
            //        per.Add(permission);
            //        _DbContext.Permissions.AddRange(per);
            //        //add
            //    }
            //    else
            //    {
            //        Permission permission = _DbContext.Permissions.Find(item.id);
            //        if(permission != null)
            //        {
            //            _DbContext.Remove(permission);
            //        }
            //    }
            //}
            //_DbContext.SaveChanges();
        }
    }
}
