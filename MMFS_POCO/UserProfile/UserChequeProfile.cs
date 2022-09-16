using MMFS_POCO.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO.UserProfile
{
    public class UserChequeProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public long? PloteAmount { get; set; }
        public string PlotePaymentMethod { get; set; }
        public string PloteRemark { get; set; }
        public long? OperationReserveAmount { get; set; }
        public string OperationReservePaymentMethod { get; set; }
        public string OperationReserveRemark { get; set; }
        public long? JVAgreementAmount { get; set; }
        public string JVAgreementPaymentMethod { get; set; }
        public string JVAgreementRemark { get; set; }
        public long? StampingAmount { get; set; }
        public string StampingPaymentMethod { get; set; }
        public string StampingRemark { get; set; }
        public long? HouseUtilitiesAmount { get; set; }
        public string HouseUtilitiesPaymentMethod { get; set; }
        public string HouseUtilitiesRemark { get; set; }
        public long? HouseFurnishingAmount { get; set; }
        public string HouseFurnishingPaymentMethod { get; set; }
        public string HouseFurnishingRemark { get; set; }
        public long? ShopLotAmount { get; set; }
        public string ShopLotPaymentMethod { get; set; }
        public string ShopLotRemark { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
