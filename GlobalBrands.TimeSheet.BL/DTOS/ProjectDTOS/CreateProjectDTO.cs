using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.DTOS.ProjectDTOS
{
    public class CreateProjectDTO
    {
        public string Name { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Description must be in range (2 => 50) character", MinimumLength = 2)]
        public string Description { get; set; } = null!;

        public DateTime DateTime { get; set; }

      
    }
}
