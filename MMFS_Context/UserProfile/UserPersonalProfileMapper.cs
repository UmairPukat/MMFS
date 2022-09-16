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
    public class UserPersonalProfileMapper
    {
        public UserPersonalProfileMapper(EntityTypeBuilder<PersonalProfile> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(m => m.Id);
            entityTypeBuilder.Property(m => m.AGPIdCard).HasColumnName("AGPIdCard").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.NewNRICNo).HasColumnName("NewNRICNo").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.OldNRICNo).HasColumnName("OldNRICNo").HasMaxLength(50).IsRequired(false);

            entityTypeBuilder.Property(m => m.MobilePhoneNo).HasColumnName("MobilePhoneNo").HasMaxLength(20);
            entityTypeBuilder.Property(m => m.Gender).HasColumnName("Gender").HasMaxLength(20);
            entityTypeBuilder.Property(m => m.DOB).HasColumnName("DOB").HasColumnType("Date").IsRequired(true);
            entityTypeBuilder.Property(m => m.JoiningDate).HasColumnName("JoiningDate").HasColumnType("Date").IsRequired(true);
            entityTypeBuilder.Property(m => m.DrivingLicenseType).HasColumnName("DrivingLicenseType").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.DrivingLicenseClass).HasColumnName("DrivingLicenseClass").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.CompanyVehiclePlateNo).HasColumnName("CompanyVehiclePlateNo").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.CompanyVehicleModel).HasColumnName("CompanyVehicleModel").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.CompanyHouseAddress).HasColumnName("CompanyHouseAddress").HasColumnType("nvarchar(MAX)").IsRequired(true);
            entityTypeBuilder.Property(m => m.Postcode).HasColumnName("Postcode").HasMaxLength(20).IsRequired(true);

            entityTypeBuilder.Property(m => m.Status).HasColumnName("Status").HasMaxLength(20);

            //Relationship
            entityTypeBuilder.HasOne(m => m.Race).WithMany(s => s.PersonalProfile).HasForeignKey(m => m.RaceId);
            entityTypeBuilder.HasOne(m => m.Religion).WithMany(s => s.PersonalProfile).HasForeignKey(m => m.ReligionId);
            entityTypeBuilder.HasOne(m => m.City).WithMany(s => s.PersonalProfile).HasForeignKey(m => m.CityId);
            entityTypeBuilder.HasOne(m => m.State).WithMany(s => s.PersonalProfile).HasForeignKey(m => m.StateId);

            entityTypeBuilder.HasOne(a => a.ApplicationUser).WithOne(mp => mp.PersonalProfile)
                .HasForeignKey<PersonalProfile>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
