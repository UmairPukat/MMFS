using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO.UserManagement
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<Permission> Permission { get; set; }
    }
}
