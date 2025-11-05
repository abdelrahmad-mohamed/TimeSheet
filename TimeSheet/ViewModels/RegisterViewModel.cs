using System.ComponentModel.DataAnnotations;

namespace GlobalBrands.TimeSheet.PL.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; } = null!;


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; } = null!;

        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="ConfirmPassword does not Match  Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; } = null!;

        
        public string? Address { get; set; } = null!;

    }
}
