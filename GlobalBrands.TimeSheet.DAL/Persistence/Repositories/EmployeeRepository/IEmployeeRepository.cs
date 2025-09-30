using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllAsync();

        public Task<Employee?> GetByIdAsync(int id);

        public Task<int> AddAsync(Employee employee);

        public Task<int> UpdateAsync(Employee employee);

        public Task<int> DeleteAsync(Employee employee);

       




    }
}
