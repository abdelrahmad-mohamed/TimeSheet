using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS
{
    public class GetAllEmployeeDTO
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public double TotalHours { get; set; }

        public double EfficiencyofCompletedTasks { get; set; }

    }
}
