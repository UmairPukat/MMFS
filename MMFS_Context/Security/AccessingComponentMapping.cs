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
    public class AccessingComponentMapping
    {
        public AccessingComponentMapping(EntityTypeBuilder<AccessingComponent> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(m => m.Id);
            entityTypeBuilder.Property(m => m.Name).HasColumnName("Name").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.Icons).HasColumnName("Icons").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.URL).HasColumnName("URL").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.CreatedDateTime).HasColumnName("CreatedDateTime").HasColumnType("Date").IsRequired(true);
            entityTypeBuilder.Property(m => m.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(50).IsRequired(false);
            entityTypeBuilder.Property(m => m.UpdatedDateTime).HasColumnName("UpdatedDateTime").HasColumnType("Date").IsRequired(false);
            entityTypeBuilder.Property(m => m.IsActive).HasColumnName("IsActive").HasMaxLength(50).IsRequired(true);
            entityTypeBuilder.Property(m => m.IsDeleted).HasColumnName("IsDeleted").IsRequired(true);
        }
    }
}
