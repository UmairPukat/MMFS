using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Models.UserProfileDto
{
    public class UserProfileDto
    {
        public string FullName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string MobilePhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Status { get; set; }
    }
}
