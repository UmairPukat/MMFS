using MMFS_POCO.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO.UserProfile
{
    public class PersonalProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string AGPIdCard { get; set; }
        public string UserTypeId { get; set; }
        public string NewNRICNo { get; set; }
        public string OldNRICNo { get; set; }
        public string MobilePhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int RaceId { get; set; }
        public int ReligionId { get; set; }
        public DateTime JoiningDate { get; set; }
        public string DrivingLicenseType { get; set; }
        public string DrivingLicenseClass { get; set; }
        public string CompanyVehiclePlateNo { get; set; }
        public string CompanyVehicleModel { get; set; }
        public string CompanyHouseAddress { get; set; }
        public string Postcode { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Race Race { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Religion Religion { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
