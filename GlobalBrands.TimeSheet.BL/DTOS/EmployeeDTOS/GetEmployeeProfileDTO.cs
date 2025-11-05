using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS
{
    public class GetEmployeeProfileDTO
    {
        public int Id  { get; set; }

        public List<EmployeeTaskDTO> Tasks { get; set; } = new List<EmployeeTaskDTO>();
    }
}
