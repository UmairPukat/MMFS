using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMFS_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Context.Security
{
    public class PermissionMapping
    {
        public PermissionMapping(EntityTypeBuilder<Permission> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(m => m.Id);
            entityTypeBuilder.Property(m => m.Status).HasColumnName("Status").HasMaxLength(10).IsRequired(true);

            //Relationship
            entityTypeBuilder.HasOne(m => m.AccessingComponent).WithMany(s => s.Permission).HasForeignKey(p => p.AccessingCompId);
            entityTypeBuilder.HasOne(m => m.ApplicationRole).WithMany(s => s.Permission).HasForeignKey(p => p.RoleId);
        }
        
    }
}
