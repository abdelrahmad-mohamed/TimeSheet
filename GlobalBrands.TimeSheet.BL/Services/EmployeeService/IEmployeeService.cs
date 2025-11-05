using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.Services.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<GetAllEmployeeDTO>> GetAll();// 

        public Task<GetEmployeeProfileDTO?> GetById(string? id);

        public Task<int> Add(CreateEmployeeDTO employee);

        public Task<int> Update(UpdateEmployeeDTO employee);

        public Task<int> Delete(Employee employee);

        public Task<IEnumerable<GetAllEmployeeDTO>> GetEmployeesByProjectId(int id);

    }
}
