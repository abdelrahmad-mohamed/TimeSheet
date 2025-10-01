using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Repositories.ProjectRepository
{
    public class ProjectRepository(TimeSheetDbContext timeSheetDbContext) : IProjectRepository
    {
        private readonly TimeSheetDbContext timeSheetDbContext = timeSheetDbContext;

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await timeSheetDbContext.Projects.AsNoTracking().ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await timeSheetDbContext.Projects.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<int> AddAsync(Project project)
        {
            timeSheetDbContext.Projects.Add(project);
            return await timeSheetDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Project project)
        {
            timeSheetDbContext.Projects.Update(project);
            return await timeSheetDbContext.SaveChangesAsync();

        }


        public async Task<int> DeleteAsync(Project project)
        {
            timeSheetDbContext.Projects.Remove(project);
            return await timeSheetDbContext.SaveChangesAsync();
        }

      

       
    }
}
