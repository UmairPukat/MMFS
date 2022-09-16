using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Models.AccountDto
{
    public class UserRoleDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
