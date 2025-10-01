using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Repositories.TaskRepository
{
    public interface ITaskRepository
    {
        public  Task<IEnumerable<ETask>> GetAllAsync();

        public Task<ETask?> GetByIdAsync(int id);

        public Task<int> AddAsync(ETask task);

        public Task<int> UpdateAsync(ETask task);

        public Task<int> DeleteAsync(ETask task);
    }
}
