using System.ComponentModel.DataAnnotations;

namespace GlobalBrands.TimeSheet.PL.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; } = null!;


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
