using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Models.AccountDto
{
    public class PermissionDto
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icons { get; set; }
        public bool Status { get; set; }
    }

    public class PermissionAssignDto
    {
        public long? id { get; set; }
        public string userId { get; set; }
        public string applicationUser { get; set; }
        public int accessingCompId { get; set; }
        public string accessingComponent { get; set; }
    }

}
