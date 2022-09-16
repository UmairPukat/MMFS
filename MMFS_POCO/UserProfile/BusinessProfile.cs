using MMFS_POCO.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO.UserProfile
{
    public class BusinessProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Company { get; set; }
        public string EnterpriseSSMNo { get; set; }
        public DateTime SSMExpiryDate { get; set; }
        public string BusinessAddress { get; set; }
        public string Postcode { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string AGPManagerName { get; set; }
        public string AGPManagerPhoneNo { get; set; }
        public string HouseType { get; set; }
        public string HomeFurnishing { get; set; }
        public string ShopLot { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public City City { get; set; }
        public State State { get; set; }
    }
}
