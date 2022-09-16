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
    public class UserEmergencyProfileMapper
    {
        public UserEmergencyProfileMapper(EntityTypeBuilder<UserEmergencyProfile> entityTypeBuilder)
        {
            // Emergency & Medical tab
            entityTypeBuilder.Property(m => m.ContactName).HasColumnName("ContactName").HasColumnType("nvarchar(MAX)").IsRequired(true);
            entityTypeBuilder.Property(m => m.Relationship).HasColumnName("Relationship").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.ContactNo).HasColumnName("ContactNo").HasMaxLength(50);
            entityTypeBuilder.Property(m => m.Vaccination).HasColumnName("Covid19Vaccination").HasColumnType("nvarchar(MAX)");

            entityTypeBuilder.HasOne(a => a.ApplicationUser).WithOne(mp => mp.UserEmergencyProfile)
                .HasForeignKey<UserEmergencyProfile>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
