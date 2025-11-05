using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS
{
    public class CreateEmployeeDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        
        [EmailAddress(ErrorMessage = "Invalid email format")]

        public string Email { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid Phone format")]
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;

        [DataType(DataType.Currency)]
        [Range(100, double.MaxValue, ErrorMessage = "Salary must be more than 100$ ")]
        public decimal Salary { get; set; }

        public string? UserId { get; set; } = null!;

    }
}
