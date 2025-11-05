using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
using GlobalBrands.TimeSheet.BL.Services.EmployeeService;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using GlobalBrands.TimeSheet.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBrands.TimeSheet.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IEmployeeService employeeService;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,IEmployeeService employeeService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.employeeService = employeeService;
        }


        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid) {

                var user = new User()
                {

                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.UserName + "@test.com",
                    EmailConfirmed = true,

                };
                
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Employee");
                    await employeeService.Add(new CreateEmployeeDTO() { UserId = user.Id, Name = user.UserName ?? string.Empty, Email = user.Email ?? string.Empty,PhoneNumber=user.PhoneNumber,Address=user.Address });
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View("Index", registerViewModel);
        }


        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) {

            if (ModelState.IsValid) {

                var user = await userManager.FindByEmailAsync(loginViewModel.UserName+"@test.com");
                if (user is not null) { 
                
                    var password= await userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if (password) {
                        var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, true);
                        if(result.IsNotAllowed)
                            ModelState.AddModelError(string.Empty, "The Account is not confirmed!");
                        if (result.IsLockedOut)
                            ModelState.AddModelError(string.Empty, "Account is Locked out!");
                        if (result.Succeeded) {
                            if (User.IsInRole("Admin"))
                                return RedirectToAction("Index", "Admin");
                            else

                            
                            return RedirectToAction("Index", "Employee");
                        }
                            


                    }
                }
              
            }
            ModelState.AddModelError(string.Empty, "Invalid UserName or Password");
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult AccessDenied() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
