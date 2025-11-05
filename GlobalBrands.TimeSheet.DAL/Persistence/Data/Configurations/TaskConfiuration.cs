using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Common;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Data.Configurations
{
    internal class TaskConfiuration : IEntityTypeConfiguration<ETask>
    {
        public void Configure(EntityTypeBuilder<ETask> builder) 
        {
        builder.Property(t => t.Id).IsRequired().HasColumnName("Task Id").UseIdentityColumn(1, 1);

            builder.Property(t => t.Title).IsRequired().HasColumnName("Task Title").HasColumnType("varchar(30)");

            builder.Property(t => t.Description).HasColumnName("Task Description").HasColumnType("varchar(max)");

            builder.Property(t => t.CompleteTask).HasDefaultValueSql("GetDate()");

            builder.Property(t => t.StartDate).HasDefaultValueSql("GetDate()");


            builder.Property(t => t.Status).IsRequired().HasColumnName("Task Status").HasConversion<string>().HasDefaultValue(Status.Pending);

      

            builder.HasOne(t => t.Employee)
                   .WithMany(e => e.Tasks)
                   .HasForeignKey(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasCheckConstraint("CK_Task_StartBeforeEnd", "[StartDate] < [EndDate]");
            builder.HasCheckConstraint("CK_Task_StartBeforeNow", "[StartDate] >= GETDATE()");
            builder.HasCheckConstraint("CK_Task_EndBeforeNow", "[EndDate] > GETDATE()");

        }
    }
}
