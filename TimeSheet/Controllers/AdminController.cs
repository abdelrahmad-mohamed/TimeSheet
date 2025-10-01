using GlobalBrands.TimeSheet.BL.Services.EmployeeService;
using GlobalBrands.TimeSheet.BL.Services.TaskService;
using GlobalBrands.TimeSheet.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBrands.TimeSheet.PL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ITaskService taskService;

        public AdminController(IEmployeeService employeeService,ITaskService taskService)
        {
            this.employeeService = employeeService;
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dashboardCards = await taskService.GetTaskStatusCount();
            var taskPerHours= await taskService.GetTaskHoursCount();
            var taskDailyTrend= await taskService.GetDailyCompletedTask();

            var DashBoardViewModel = new DashboardViewModel()
            {
                DashboardCard = dashboardCards,
                TaskPerHour = taskPerHours,
                TaskDailyTrend = taskDailyTrend,
            };
            return View(DashBoardViewModel);
        }
    }
}
