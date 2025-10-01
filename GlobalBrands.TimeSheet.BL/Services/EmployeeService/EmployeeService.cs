using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.EmployeeRepository;

namespace GlobalBrands.TimeSheet.BL.Services.EmployeeService
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository = employeeRepository;

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetById(int id)
        {
            if(id<=0)
                return null;
            return await employeeRepository.GetByIdAsync(id);
        }
        public async Task<int> Add(CreateEmployeeDTO employee)
        {
            var employeeEntity = new Employee()
            {
                Name = employee.Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                Salary = employee.Salary
            };

            var result= await employeeRepository.AddAsync(employeeEntity);
            return result>0?result:0;
        }

        public async Task<int> Update(UpdateEmployeeDTO employee)
        {
            var existingEmployee = employeeRepository.GetByIdAsync(employee.Id);
            if (existingEmployee == null)
                return 0;

            var employeeEntity = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                Salary = employee.Salary
            };

            var result =await employeeRepository.UpdateAsync(employeeEntity);
            return result > 0 ? result : 0;

           
        }

        public async Task<int> Delete(Employee employee)
        {
            var existingEmployee = employeeRepository.GetByIdAsync(employee.Id);
            if (existingEmployee == null)
                return 0;

            if (employee is null)
                return 0;
            var result =await employeeRepository.DeleteAsync(employee);
            return result > 0 ? result : 0;

        }

    }
}
