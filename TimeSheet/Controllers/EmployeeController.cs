using GlobalBrands.TimeSheet.BL.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBrands.TimeSheet.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}