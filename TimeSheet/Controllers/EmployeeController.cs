using System.Security.Claims;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
using GlobalBrands.TimeSheet.BL.DTOS.ProjectDTOS;
using GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS;
using GlobalBrands.TimeSheet.BL.Services.EmployeeService;
using GlobalBrands.TimeSheet.BL.Services.ProjectService;
using GlobalBrands.TimeSheet.BL.Services.TaskService;
using GlobalBrands.TimeSheet.DAL.Common;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GlobalBrands.TimeSheet.PL.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IProjectService projectService;
        private readonly ITaskService taskService;
        private readonly UserManager<User> userManager;

        public EmployeeController(IEmployeeService employeeService, IProjectService projectService, ITaskService taskService,UserManager<User> userManager)
        {
            this.employeeService = employeeService;
            this.projectService = projectService;
            this.taskService = taskService;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var currentUser = await userManager.GetUserAsync(User);

            var projects = await projectService.GetAll();
            var tasks = await taskService.GetTaskStatusCount();
            var employeeProfile = await employeeService.GetById(currentUser.Id);
            ViewBag._Projects = projects;
            ViewBag._Status = new SelectList(Enum.GetNames(typeof(Status)));
            ViewBag._Tasks = tasks;
            return View(employeeProfile);
        }



        [HttpPost]
        public async  Task<IActionResult> Delete(int Id)
        {

            var task= await taskService.GetById(Id);
            var taskEntity = await taskService.Delete(task);
            if (taskEntity > 0) {
                TempData["Message"] = "Task Deleted Successfully";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Task Deletion Failed";
            return RedirectToAction("Index");

        }










        [HttpPost]
        public async Task<IActionResult> CreateTask(EmployeeTaskDTO employeeTaskDTO)
        {
            var currentUser = await userManager.GetUserAsync(User);
            ModelState.Remove("ProjectName");

            var employee = await employeeService.GetById(currentUser.Id);
            employeeTaskDTO.EmployeeId = employee.Id;

            var projects = await projectService.GetAll();

            if (ModelState.IsValid)
            {
                var (success, errorMessage) = await taskService.Add(employeeTaskDTO);

                if (success)
                {

                    TempData["Message"] = "Task Created Successfully";
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Employee") });
                }
                else
                {
                    //ModelState.AddModelError("StartDate", errorMessage);
                    //ModelState.AddModelError("EndDate", errorMessage);

                    ModelState.AddModelError("", errorMessage);

                }
            }
            



            projects = await projectService.GetAll();
            ViewData["Projects"] = projects;

            return PartialView("CreateTaskPartialView", employeeTaskDTO);
        }



        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDTO createProjectDTO) {

            if (ModelState.IsValid) { 
            var project = await projectService.Add(createProjectDTO);
                if (project > 0)
                {
                    TempData["Message"] = "Project Created Successfully";
                }
                else
                {
                    TempData["Message"] = "Project Creation Failed";
                }
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Employee") });
            }
               return PartialView("CreateProjectPartialView", createProjectDTO);
        }











        [HttpPost]
        public async Task<IActionResult> EditTask(EmployeeTaskDTO UpdateTaskDTO)
        {
            ModelState.Remove("StartDate");
            ModelState.Remove("ProjectId");
            ModelState.Remove("ProjectName");
            if (ModelState.IsValid)
            {
                var(success, errorMessage)= await taskService.Update(UpdateTaskDTO);
                if (success)
                {
                    TempData["Message"] = "Task Updated Successfully";
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Employee") });

                }
                else {

                        ModelState.AddModelError("", errorMessage);
                }

             
            }
            var projects = await projectService.GetAll();
            ViewBag._Status = new SelectList(Enum.GetNames(typeof(Status)));
            return PartialView("EditTaskPartialView",UpdateTaskDTO);
        }


    }
}