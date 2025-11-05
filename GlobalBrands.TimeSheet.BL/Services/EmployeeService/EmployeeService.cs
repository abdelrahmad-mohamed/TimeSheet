using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
using GlobalBrands.TimeSheet.DAL.Common;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.EmployeeRepository;

namespace GlobalBrands.TimeSheet.BL.Services.EmployeeService
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository = employeeRepository;

        public async Task<IEnumerable<GetAllEmployeeDTO>> GetAll()
        {
            var employees = await employeeRepository.GetAllAsync();
            var employeeEntity = employees.Select(e => new GetAllEmployeeDTO()
            {
                Name = e.Name,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                TotalHours = e.Tasks.Sum(t => t.NoOfHours),
                // Efficiency calculation can be added here if needed
                EfficiencyofCompletedTasks = e.Tasks.Any() ? (int)((e.Tasks.Where(t => t.Status == Status.Completed).Sum(t => t.NoOfHours) / (double)e.Tasks.Sum(t=>t.NoOfHours)) * 100) : 0

            }).ToList();
            return employeeEntity;
        }

        public async Task<GetEmployeeProfileDTO?> GetById(string? id)
        {
            if(id is null)
                return null;
            var employee=  await employeeRepository.GetByIdAsync(id);
            var employeeEntity = new GetEmployeeProfileDTO
            {
                Id = employee.Id,
                Tasks = employee.Tasks.Select(t => new EmployeeTaskDTO
                {
                    Id= t.Id,
                    TaskName = t.Title,
                    Description = t.Description,
                    ProjectName = t.Project.Name,
                    ProjectId = t.ProjectId,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Status = t.Status.ToString(),
                    EmployeeId =employee.Id
                }).ToList()
            };

            return employeeEntity;

        }
        public async Task<int> Add(CreateEmployeeDTO employee)
        {
            var employeeEntity = new Employee()
            {
                Name = employee.Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                UserId = employee.UserId
            };

            var result= await employeeRepository.AddAsync(employeeEntity);
            return result>0?result:0;
        }

        public async Task<int> Update(UpdateEmployeeDTO employee)
        {
            var existingEmployee = employeeRepository.GetByIdAsync(employee.UserId);
            if (existingEmployee == null)
                return 0;

            var employeeEntity = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address
            };

            var result =await employeeRepository.UpdateAsync(employeeEntity);
            return result > 0 ? result : 0;

           
        }

        public async Task<int> Delete(Employee employee)
        {
            var existingEmployee = employeeRepository.GetByIdAsync(employee.UserId);
            if (existingEmployee == null)
                return 0;

            if (employee is null)
                return 0;
            var result =await employeeRepository.DeleteAsync(employee);
            return result > 0 ? result : 0;

        }

        public async Task<IEnumerable<GetAllEmployeeDTO>> GetEmployeesByProjectId(int id) { 
        
            var employees=await employeeRepository.GetEmployeesByProjectId(id);
            if(employees == null)
                return Enumerable.Empty<GetAllEmployeeDTO>();
            var employeeEntity = employees.Select(e => new GetAllEmployeeDTO() {
                Name = e.Name,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
            }).ToList();
            return employeeEntity;
        }

    }
}
