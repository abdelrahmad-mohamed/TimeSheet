using GlobalBrands.TimeSheet.BL.Services.EmployeeService;
using GlobalBrands.TimeSheet.BL.Services.ProjectService;
using GlobalBrands.TimeSheet.BL.Services.TaskService;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.EmployeeRepository;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.ProjectRepository;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.TaskRepository;
using Microsoft.EntityFrameworkCore;

namespace TimeSheet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TimeSheetDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );
            /*Register service of Repositories to CLR*/
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<ITaskRepository,TaskRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

            /*Register service of Services to CLR*/
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddScoped<ITaskService, TaskService>();

            builder.Services.AddScoped<IProjectService,ProjectService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
