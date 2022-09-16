using MMFS_POCO.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMFS_Services.Models
{
    public class UserProfileForEditDto
    {
        public PersonalProfile PersonalProfile { get; set; }
        public BusinessProfile BusinessProfile { get; set; }
        public UserEmergencyProfile UserEmergencyProfile { get; set; }
        public UserChequeProfile UserChequeProfile { get; set; }
    }
}
