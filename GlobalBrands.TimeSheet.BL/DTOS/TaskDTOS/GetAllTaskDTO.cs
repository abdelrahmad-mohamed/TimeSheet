using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS
{
    public class GetAllTaskDTO
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = null!;

        public string ProjectName { get; set; } = null!;


        public string EmployeeName { get; set; } = null!;

        public double Hours { get; set; }


        public string Status { get; set; } = null!;


    }
}
