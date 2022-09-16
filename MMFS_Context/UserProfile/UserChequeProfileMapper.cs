using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMFS_POCO.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Context.UserProfile
{
    public class UserChequeProfileMapper
    {
        public UserChequeProfileMapper(EntityTypeBuilder<UserChequeProfile> entityTypeBuilder)
        {
            entityTypeBuilder.Property(m => m.PloteAmount).HasColumnName("PloteAmount").IsRequired(false);
            entityTypeBuilder.Property(m => m.PlotePaymentMethod).HasColumnName("PlotePaymentMethod").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.PloteRemark).HasColumnName("PloteRemark").HasColumnType("nvarchar(MAX)").IsRequired(false);

            entityTypeBuilder.Property(m => m.OperationReserveAmount).HasColumnName("OperationReserveAmount").IsRequired(false);
            entityTypeBuilder.Property(m => m.OperationReservePaymentMethod).HasColumnName("OperationReservePaymentMethod").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.OperationReserveRemark).HasColumnName("OperationReserveRemark").HasColumnType("nvarchar(MAX)").IsRequired(false);

            entityTypeBuilder.Property(m => m.JVAgreementAmount).HasColumnName("JVAgreementAmount").IsRequired(false);
            entityTypeBuilder.Property(m => m.JVAgreementPaymentMethod).HasColumnName("JVAgreementPaymentMethod").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.JVAgreementRemark).HasColumnName("JVAgreementRemark").HasColumnType("nvarchar(MAX)").IsRequired(false);

            entityTypeBuilder.Property(m => m.StampingAmount).HasColumnName("StampingAmount").IsRequired(false);
            entityTypeBuilder.Property(m => m.StampingPaymentMethod).HasColumnName("StampingPaymentMethod").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.StampingRemark).HasColumnName("StampingRemark").HasColumnType("nvarchar(MAX)").IsRequired(false);

            entityTypeBuilder.Property(m => m.HouseUtilitiesAmount).HasColumnName("HouseUtilitiesAmount").IsRequired(false);
            entityTypeBuilder.Property(m => m.HouseUtilitiesPaymentMethod).HasColumnName("HouseUtilitiesPaymentMethod").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.HouseUtilitiesRemark).HasColumnName("HouseUtilitiesRemark").HasColumnType("nvarchar(MAX)").IsRequired(false);

            entityTypeBuilder.Property(m => m.HouseFurnishingAmount).HasColumnName("HouseFurnishingAmount").IsRequired(false);
            entityTypeBuilder.Property(m => m.HouseFurnishingPaymentMethod).HasColumnName("HouseFurnishingPaymentMethod").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.HouseFurnishingRemark).HasColumnName("HouseFurnishingRemark").HasColumnType("nvarchar(MAX)").IsRequired(false);

            entityTypeBuilder.Property(m => m.ShopLotAmount).HasColumnName("ShopLotAmount").IsRequired(false);
            entityTypeBuilder.Property(m => m.ShopLotPaymentMethod).HasColumnName("ShopLotPaymentMethod").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.ShopLotRemark).HasColumnName("ShopLotRemark").HasColumnType("nvarchar(MAX)").IsRequired(false);

            entityTypeBuilder.HasOne(a => a.ApplicationUser).WithOne(mp => mp.UserChequeProfile)
                .HasForeignKey<UserChequeProfile>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
