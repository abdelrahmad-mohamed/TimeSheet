using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Common;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.ProjectRepository;
using Microsoft.EntityFrameworkCore;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Repositories.TaskRepository
{
    public class TaskRepository(TimeSheetDbContext timeSheetDbContext) : ITaskRepository
    {
        private readonly TimeSheetDbContext timeSheetDbContext = timeSheetDbContext;

        public async Task<IEnumerable<ETask>> GetAllAsync()
        {
            return await timeSheetDbContext.Tasks.Include(e => e.Project).Include(e=>e.Employee).AsNoTracking().ToListAsync();
        }

        public async  Task<ETask?> GetByIdAsync(int id)
        {
            return await timeSheetDbContext.Tasks.Include(e => e.Project).Include(e => e.Employee).FirstOrDefaultAsync(e=>e.Id==id);
        }
        public async Task<int> AddAsync(ETask task)
        {
             timeSheetDbContext.Add(task);
            return await timeSheetDbContext.SaveChangesAsync();
        }


        public async Task<int> UpdateAsync(ETask task)
        {
            if (task.Status == Status.Completed && task.CompleteTask==null)
            {
                task.CompleteTask = DateTime.Now;
            }
            timeSheetDbContext.Update(task);
            return await timeSheetDbContext.SaveChangesAsync();
        }


        public async Task<int> DeleteAsync(ETask task)
        {
            timeSheetDbContext.Remove(task);
            return await timeSheetDbContext.SaveChangesAsync();
        }
    }
}
