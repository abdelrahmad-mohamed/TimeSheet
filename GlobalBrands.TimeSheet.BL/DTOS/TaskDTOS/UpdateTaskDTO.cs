using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Common;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS
{
    public class UpdateTaskDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;


        public string Description { get; set; } = null!;


        public DateTime EndDate { get; set; }
        public Status Status { get; set; }

        public Category Category { get; set; }


        /*Foreign key*/
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
    }
}
