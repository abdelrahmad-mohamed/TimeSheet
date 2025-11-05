using System;
using GlobalBrands.TimeSheet.DAL.Common;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class TimeSheetDbContext : IdentityDbContext<User>
{
    public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
    {
    }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ✅ Apply all IEntityTypeConfiguration classes automatically
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TimeSheetDbContext).Assembly);


        //// ✅ Seed Employees
        //modelBuilder.Entity<Employee>().HasData(
        //    new Employee
        //    {
        //        Id = 1,
        //        Name = "Ahmed Ali",
        //        Email = "ahmed.ali@example.com",
        //        PhoneNumber = "01012345678",
        //        Address = "Cairo, Egypt"
        //    },
        //    new Employee
        //    {
        //        Id = 2,
        //        Name = "Sara Mohamed",
        //        Email = "sara.mohamed@example.com",
        //        PhoneNumber = "01198765432",
        //        Address = "Alexandria, Egypt"
        //    }
        //);

        //// ✅ Seed Projects
        //modelBuilder.Entity<Project>().HasData(
        //    new Project
        //    {
        //        Id = 1,
        //        Name = "Time Tracking System",
        //        Description = "Internal project to track working hours"
        //    },
        //    new Project
        //    {
        //        Id = 2,
        //        Name = "E-Commerce Platform",
        //        Description = "Web platform for online shopping"
        //    }
        //);

        //// ✅ Seed Tasks
        //modelBuilder.Entity<ETask>().HasData(
        //    new ETask
        //    {
        //        Id = 1,
        //        Title = "Design DB",
        //        Description = "Create ERD and schema",
        //        StartDate = new DateTime(2025, 10, 19, 5, 0, 0),
        //        EndDate = new DateTime(2025, 10, 19, 8, 0, 0),
        //        Status = Status.InProgress,
        //        CompleteTask = null,
        //        EmployeeId = 1,
        //        ProjectId = 1
        //    },
        //    new ETask
        //    {
        //        Id = 2,
        //        Title = "API Setup",
        //        Description = "Build initial API endpoints",
        //        StartDate = new DateTime(2025, 10, 19, 6, 0, 0),
        //        EndDate = new DateTime(2025, 10, 20, 15, 0, 0),
        //        Status = Status.InProgress,
        //        CompleteTask = null,
        //        EmployeeId = 1,
        //        ProjectId = 1
        //    },
        //    new ETask
        //    {
        //        Id = 3,
        //        Title = "Product Module",
        //        Description = "Implement product catalog",
        //        StartDate = new DateTime(2025, 10, 19, 6, 0, 0),
        //        EndDate = new DateTime(2025, 10, 20, 15, 0, 0),
        //        Status = Status.Completed,
        //        CompleteTask = new DateTime(2025, 10, 21, 17, 0, 0),
        //        EmployeeId = 1,
        //        ProjectId = 2
        //    },
        //    new ETask
        //    {
        //        Id = 4,
        //        Title = "Cart Module",
        //        Description = "Implement shopping cart",
        //        StartDate = new DateTime(2025, 10, 22, 9, 0, 0),
        //        EndDate = new DateTime(2025, 10, 22, 17, 0, 0),
        //        Status = Status.Pending,
        //        CompleteTask = null,
        //        EmployeeId = 1,
        //        ProjectId = 2
        //    },
        //    new ETask
        //    {
        //        Id = 5,
        //        Title = "Testing API",
        //        Description = "Write unit tests",
        //        StartDate = new DateTime(2025, 10, 23, 9, 0, 0),
        //        EndDate = new DateTime(2025, 10, 23, 17, 0, 0),
        //        Status = Status.InProgress,
        //        CompleteTask = null,
        //        EmployeeId = 2,
        //        ProjectId = 1
        //    },
        //    new ETask
        //    {
        //        Id = 6,
        //        Title = "UI Review",
        //        Description = "Check frontend components",
        //        StartDate = new DateTime(2025, 10, 23, 9, 0, 0),
        //        EndDate = new DateTime(2025, 10, 23, 17, 0, 0),
        //        Status = Status.Completed,
        //        CompleteTask = new DateTime(2025, 10, 24, 18, 0, 0),
        //        EmployeeId = 2,
        //        ProjectId = 1
        //    },
        //    new ETask
        //    {
        //        Id = 7,
        //        Title = "Payment Module",
        //        Description = "Test payment gateway",
        //        StartDate = new DateTime(2025, 10, 24, 9, 0, 0),
        //        EndDate = new DateTime(2025, 10, 24, 17, 0, 0),
        //        Status = Status.InProgress,
        //        CompleteTask = null,
        //        EmployeeId = 2,
        //        ProjectId = 2
        //    },
        //    new ETask
        //    {
        //        Id = 8,
        //        Title = "Bug Report",
        //        Description = "Document found issues",
        //        StartDate = new DateTime(2025, 10, 25, 9, 0, 0),
        //        EndDate = new DateTime(2025, 10, 25, 17, 0, 0),
        //        Status = Status.InProgress,
        //        CompleteTask = null,
        //        EmployeeId = 2,
        //        ProjectId = 2
        //    }
        //);
    }

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ETask> Tasks { get; set; } = null!;

}
