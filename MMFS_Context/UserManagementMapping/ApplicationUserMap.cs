using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMFS_POCO.UserManagement;
using MMFS_POCO.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Context.UserManagementMapping
{
    public class ApplicationUserMap
    {
        public ApplicationUserMap(EntityTypeBuilder<ApplicationUser> entityTypeBuilder)
        {
            entityTypeBuilder.Property(m => m.FullName).HasColumnName("FullName").HasMaxLength(150).IsRequired(true);
            
            entityTypeBuilder.Property(m => m.VarificationCode).HasColumnName("VarificationCode").IsRequired(false);
            entityTypeBuilder.Property(m => m.CodeValidDate).HasColumnName("CodeValidDate").HasColumnType("Date").IsRequired(false);
            entityTypeBuilder.Property(m => m.LastModifiedDateTime).HasColumnName("LastModifiedDateTime").HasColumnType("Date").IsRequired(false);

            

        }
    }
}