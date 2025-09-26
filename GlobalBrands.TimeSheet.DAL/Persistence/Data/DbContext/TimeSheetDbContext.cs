using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Common;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.EntityFrameworkCore;


    public class TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : DbContext(options)
    {
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TimeSheetDbContext).Assembly);

        base.OnModelCreating(modelBuilder);

        // Seed Employees
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "Ahmed Ali",
                Email = "Ahmedli@example.com",
                PhoneNumber = "01012345678",
                Address = "Cairo, Egypt",
                DateOfBirth = new DateOnly(1995, 5, 12),
                Position = "Software Developer",
                Salary = 15000,
                AzureObjectId = null
            },
            new Employee
            {
                Id = 2,
                Name = "Sara Mohamed",
                Email = "sara.mohamed@example.com",
                PhoneNumber = "01198765432",
                Address = "Alexandria, Egypt",
                DateOfBirth = new DateOnly(1998, 8, 20),
                Position = "QA Engineer",
               
                Salary = 12000,
                AzureObjectId = null
            }
        );

        // Seed Projects
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Name = "Time Tracking System",
                Description = "Internal project to track working hours"
            },
            new Project
            {
                Id = 2,
                Name = "E-Commerce Platform",
                Description = "Web platform for online shopping"
            }
        );

        // Seed Tasks (8 tasks → 4 for each employee across 2 projects)
        modelBuilder.Entity<ETask>().HasData(
           
            new ETask { Id = 1, Title = "Design DB", Description = "Create ERD and schema", NoOfHours = 5, Status = Status.InProgress, EmployeeId = 1, ProjectId = 1 },
            new ETask { Id = 2, Title = "API Setup", Description = "Build initial API endpoints", NoOfHours = 6, Status = Status.InProgress, EmployeeId = 1, ProjectId = 1 },
           
            new ETask { Id = 3, Title = "Product Module", Description = "Implement product catalog", NoOfHours = 7, Status = Status.Completed, EmployeeId = 1, ProjectId = 2 },
            new ETask { Id = 4, Title = "Cart Module", Description = "Implement shopping cart", NoOfHours = 4, Status = Status.NotStarted, EmployeeId = 1, ProjectId = 2 },

           
            new ETask { Id = 5, Title = "Testing API", Description = "Write unit tests", NoOfHours = 5, Status = Status.InProgress, EmployeeId = 2, ProjectId = 1 },
            new ETask { Id = 6, Title = "UI Review", Description = "Check frontend components", NoOfHours = 3, Status = Status.Completed, EmployeeId = 2, ProjectId = 1 },
          
            new ETask { Id = 7, Title = "Payment Module", Description = "Test payment gateway", NoOfHours = 6, Status = Status.InProgress, EmployeeId = 2, ProjectId = 2 },
            new ETask { Id = 8, Title = "Bug Report", Description = "Document found issues", NoOfHours = 4, Status = Status.InProgress, EmployeeId = 2, ProjectId = 2 }
    );
    }

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ETask> Tasks { get; set; } = null!;
}



     
    