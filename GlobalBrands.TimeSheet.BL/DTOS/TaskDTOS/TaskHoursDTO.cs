using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS
{
    public class TaskHoursDTO
    {

        public double TotalHours { get; set; }

        public string EmployeeName { get; set; } = null!;

        public int EmployeeId { get; set; }
        
    }
}
