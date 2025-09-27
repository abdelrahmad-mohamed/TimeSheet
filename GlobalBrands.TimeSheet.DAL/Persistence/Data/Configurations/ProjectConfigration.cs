using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(builder => builder.Id).IsRequired().HasColumnName("Project Id").UseIdentityColumn(1, 1);

            builder.Property(builder => builder.Name).IsRequired().HasColumnName("Project Name");

            builder.Property(builder => builder.Description).HasColumnName("Project Description");

            builder.Property(builder => builder.DateTime)
     .HasDefaultValueSql("GETDATE()");

            builder.HasMany(p => p.Tasks)
                   .WithOne(t => t.Project)
                   .HasForeignKey(t => t.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
