using MMFS_POCO.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO.UserProfile
{
    public class UserEmergencyProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ContactName { get; set; }
        public string Relationship { get; set; }
        public string ContactNo { get; set; }
        public string Vaccination { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
