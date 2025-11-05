using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Repositories.EmployeeRepository
{
    public class EmployeeRepository(TimeSheetDbContext timeSheetDbContext) : IEmployeeRepository
    {
        private readonly TimeSheetDbContext timeSheetDbContext = timeSheetDbContext;

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
           return await timeSheetDbContext.Employees.Include(e=>e.Tasks).ThenInclude(e=>e.Project).AsNoTracking().ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(string? id)
        {

            return await timeSheetDbContext.Employees.Include(e => e.Tasks).ThenInclude(e => e.Project).AsNoTracking().FirstOrDefaultAsync(e => e.UserId==id);
        }

        public async Task<int> AddAsync(Employee employee)
        {
             timeSheetDbContext.Employees.Add(employee);
            return await timeSheetDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
             timeSheetDbContext.Employees.Update(employee);
            return await timeSheetDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Employee employee)
        {
            timeSheetDbContext.Employees.Remove(employee);
            return await timeSheetDbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Employee>> GetEmployeesByProjectId(int projectId)
        {
            var employees = await timeSheetDbContext.Employees
                .Include(e => e.Tasks)
                .Where(e => e.Tasks.Any(t => t.ProjectId == projectId))
                .ToListAsync();

            return employees;
        }



    }
}
