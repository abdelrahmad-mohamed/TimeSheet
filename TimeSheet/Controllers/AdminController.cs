using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
using GlobalBrands.TimeSheet.BL.Services.EmployeeService;
using GlobalBrands.TimeSheet.BL.Services.ProjectService;
using GlobalBrands.TimeSheet.BL.Services.TaskService;
using GlobalBrands.TimeSheet.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBrands.TimeSheet.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ITaskService taskService;
        private readonly IProjectService projectService;

        public AdminController(IEmployeeService employeeService,ITaskService taskService,IProjectService projectService)
        {
            this.employeeService = employeeService;
            this.taskService = taskService;
            this.projectService = projectService;
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

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var employees = await employeeService.GetAll();
            return View(employees);
        }


        [HttpGet]
        public async Task<IActionResult> Projects()
        {
            var projects = await projectService.GetAll();
            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> Tasks()
        {
            var tasks = await taskService.GetAll();
            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> TaskInfo([FromRoute] int? id)
        {

            if (!id.HasValue)
                return BadRequest();

            var task = await taskService.GetTasksByProjectId(id.Value);
            var taskViewModel=task.Select(t => new ProjectTasksViewModel()
            {
                Title = t.Title,
                Description = t.Description,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Status = t.Status,
            }).ToList();
            var projectName = await projectService.GetById(id.Value);
            ViewBag.ProjectName = projectName?.Name;

            return View(taskViewModel);


        }

        [HttpGet]
        public async Task<IActionResult> EmployeesInfo([FromRoute] int? id)
        {

            if (!id.HasValue)
                return BadRequest();

            var employees = await employeeService.GetEmployeesByProjectId(id.Value);
            var projectName = await projectService.GetById(id.Value);
            ViewBag.ProjectName = projectName?.Name;

            return View(employees);


        }

    }
}
