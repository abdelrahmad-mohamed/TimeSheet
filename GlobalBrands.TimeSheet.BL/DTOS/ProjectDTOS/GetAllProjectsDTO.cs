using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.DTOS.ProjectDTOS
{
    public class GetAllProjectsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime DateTime { get; set; }

        public int NoOfEmployees { get; set; }

        public int NoOfTasks { get; set; }

        public decimal PrecentageOfCompletence { get; set; }

    }
}
