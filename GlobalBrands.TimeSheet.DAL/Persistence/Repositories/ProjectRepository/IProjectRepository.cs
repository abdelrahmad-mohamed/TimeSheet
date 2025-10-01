using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Project>> GetAllAsync();

        public Task<Project?> GetByIdAsync(int id);

        public Task<int> AddAsync(Project project);

        public Task<int> UpdateAsync(Project project);

        public Task<int> DeleteAsync(Project project);
    }
}
