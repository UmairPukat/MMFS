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
    public class UserBusinessProfileMapper
    {
        public UserBusinessProfileMapper(EntityTypeBuilder<BusinessProfile> entityTypeBuilder)
        {
            //Business Tab
            entityTypeBuilder.HasKey(m => m.Id);
            entityTypeBuilder.Property(m => m.Company).HasColumnName("Company").HasColumnType("nvarchar(MAX)").IsRequired(true);
            entityTypeBuilder.Property(m => m.EnterpriseSSMNo).HasColumnName("EnterpriseSSMNo").HasMaxLength(20).IsRequired(true);
            entityTypeBuilder.Property(m => m.SSMExpiryDate).HasColumnName("SSMExpiryDate").HasColumnType("Date").IsRequired(true);
            entityTypeBuilder.Property(m => m.BusinessAddress).HasColumnName("BusinessAddress").HasColumnType("nvarchar(MAX)").IsRequired(true);
            entityTypeBuilder.Property(m => m.Postcode).HasColumnName("Postcode").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.BankAccountNo).HasColumnName("BankAccountNo").HasMaxLength(20).IsRequired(true);
            entityTypeBuilder.Property(m => m.AGPManagerName).HasColumnName("AGPManagerName").HasColumnType("nvarchar(MAX)").IsRequired(true);
            entityTypeBuilder.Property(m => m.AGPManagerPhoneNo).HasColumnName("AGPManagerPhoneNo").HasMaxLength(20).IsRequired(true);
            entityTypeBuilder.Property(m => m.HouseType).HasColumnName("HouseType").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.HomeFurnishing).HasColumnName("HomeFurnishing").HasMaxLength(20).IsRequired(false);
            entityTypeBuilder.Property(m => m.ShopLot).HasColumnName("ShopLot").HasMaxLength(20).IsRequired(false);

            entityTypeBuilder.HasOne(m => m.City).WithMany(s => s.BusinessProfile).HasForeignKey(m => m.CityId);
            entityTypeBuilder.HasOne(m => m.State).WithMany(s => s.BusinessProfile).HasForeignKey(m => m.StateId);

            entityTypeBuilder.HasOne(a => a.ApplicationUser).WithOne(mp => mp.BusinessProfile)
                .HasForeignKey<BusinessProfile>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
