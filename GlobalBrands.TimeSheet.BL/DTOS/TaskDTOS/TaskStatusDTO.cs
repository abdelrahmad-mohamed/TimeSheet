using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Common;

namespace GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS
{
    public class TaskStatusDTO
    {
        public int EmployeeCount { get; set; }

        public int TaskCount { get; set; }

        public Status Status { get; set; }
    }
}
