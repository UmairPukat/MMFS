using MMFS_POCO.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO
{
    public class Permission
    {
        public long Id { get; set; }
        public string RoleId { get; set; }
        public bool Status { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
        public int AccessingCompId { get; set; }
        public AccessingComponent AccessingComponent { get; set; }
       
    }
}
