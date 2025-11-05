using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Data.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id).IsRequired().HasColumnName("Employee Id").UseIdentityColumn(1,1);

            builder.Property(e => e.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50).HasColumnName("Employee Name");

            builder.Property(e => e.Email).IsRequired().HasColumnType("varchar").HasMaxLength(100).HasColumnName("Employee Email");

        
          

            builder.HasMany(e => e.Tasks)
                   .WithOne(t => t.Employee)
                   .HasForeignKey(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
