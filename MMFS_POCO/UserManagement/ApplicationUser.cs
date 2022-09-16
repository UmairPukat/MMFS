using Microsoft.AspNetCore.Identity;
using MMFS_POCO.UserProfile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO.UserManagement
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }

        

        //for helping
        public int VarificationCode { get; set; }
        public DateTime CodeValidDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public string Image { get; set; }
        public PersonalProfile PersonalProfile { get; set; }
        public BusinessProfile BusinessProfile { get; set; }
        public UserEmergencyProfile UserEmergencyProfile { get; set; }
        public UserChequeProfile UserChequeProfile { get; set; }
    }
}
