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
     new ETask
     {
         Id = 1,
         Title = "Design DB",
         Description = "Create ERD and schema",
         StartDate = new DateTime(2025, 9, 27, 9, 0, 0),  // 27-09-2025 at 9:00 AM
         EndDate = new DateTime(2025, 9, 27, 17, 0, 0),   // 27-09-2025 at 5:00 PM
         Status = Status.InProgress,
         CompleteTask=null,
         EmployeeId = 1,
         ProjectId = 1,
         Category = Category.Research
     },
     new ETask
     {
         Id = 2,
         Title = "API Setup",
         Description = "Build initial API endpoints",
         StartDate = new DateTime(2025, 9, 27, 9, 0, 0),  // 27-09-2025 at 9:00 AM
         EndDate = new DateTime(2025, 9, 27, 17, 0, 0),   // 27-09-2025 at 5:00 PM
         Status = Status.InProgress,
         CompleteTask=null,
         EmployeeId = 1,
         ProjectId = 1,
         Category = Category.FeatureDevelopment
     },
     new ETask
     {
         Id = 3,
         Title = "Product Module",
         Description = "Implement product catalog",
         StartDate = new DateTime(2025, 9, 27, 9, 0, 0),  // 27-09-2025 at 9:00 AM
         EndDate = new DateTime(2025, 9, 27, 17, 0, 0),   // 27-09-2025 at 5:00 PM
         Status = Status.Completed,
         CompleteTask= new DateTime(2025, 9, 27, 17, 0, 0),
         EmployeeId = 1,
         ProjectId = 2,
         Category = Category.FeatureDevelopment
     },
     new ETask
     {
         Id = 4,
         Title = "Cart Module",
         Description = "Implement shopping cart",
         StartDate = new DateTime(2025, 9, 27, 9, 0, 0),  // 27-09-2025 at 9:00 AM
         EndDate = new DateTime(2025, 9, 27, 17, 0, 0),   // 27-09-2025 at 5:00 PM
         Status = Status.Pending,
         CompleteTask=null,
         EmployeeId = 1,
         ProjectId = 2,
         Category = Category.FeatureDevelopment
     },
     new ETask
     {
         Id = 5,
         Title = "Testing API",
         Description = "Write unit tests",
         StartDate = new DateTime(2025, 9, 27, 9, 0, 0),  // 27-09-2025 at 9:00 AM
         EndDate = new DateTime(2025, 9, 27, 17, 0, 0),   // 27-09-2025 at 5:00 PM
         Status = Status.InProgress,
         CompleteTask=null,
         EmployeeId = 2,
         ProjectId = 1,
         Category = Category.Testing
     },
     new ETask
     {
         Id = 6,
         Title = "UI Review",
         Description = "Check frontend components",
         StartDate = new DateTime(2025, 9, 27, 9, 0, 0),  // 27-09-2025 at 9:00 AM
         EndDate = new DateTime(2025, 9, 27, 17, 0, 0),   // 27-09-2025 at 5:00 PM
         Status = Status.Completed,
         CompleteTask = new DateTime(2025, 9, 29, 18, 0, 0),
         EmployeeId = 2,
         ProjectId = 1,
         Category = Category.Improvement
     },
     new ETask
     {
         Id = 7,
         Title = "Payment Module",
         Description = "Test payment gateway",
         StartDate = new DateTime(2025, 9, 27, 9, 0, 0),  // 27-09-2025 at 9:00 AM
         EndDate = new DateTime(2025, 9, 27, 17, 0, 0),   // 27-09-2025 at 5:00 PM
         Status = Status.InProgress,
         CompleteTask = null,
         EmployeeId = 2,
         ProjectId = 2,
         Category = Category.Testing
     },
     new ETask
     {
         Id = 8,
         Title = "Bug Report",
         Description = "Document found issues",
         StartDate = new DateTime(2025, 9, 27, 9, 0, 0),  // 27-09-2025 at 9:00 AM
         EndDate = new DateTime(2025, 9, 27, 17, 0, 0),   // 27-09-2025 at 5:00 PM
         CompleteTask = null,
         Status = Status.InProgress,
         EmployeeId = 2,
         ProjectId = 2,
         Category = Category.Documentation
     }
 );
    }

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ETask> Tasks { get; set; } = null!;
}



     
    