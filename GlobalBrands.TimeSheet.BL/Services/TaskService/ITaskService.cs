using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.ProjectDTOS;
using GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.Services.TaskService
{
    public interface ITaskService
    {
        public Task<IEnumerable<ETask>> GetAll();

        public Task<ETask?> GetById(int id);

        public Task<int> Add(CreateTaskDTO task);

        public Task<int> Update(UpdateTaskDTO task);

        public Task<int> Delete(ETask employee);

        public Task<List<TaskStatusDTO>> GetTaskStatusCount();

        public Task<List<TaskHoursDTO>> GetTaskHoursCount();

        public Task<List<TaskTrendDTO>> GetDailyCompletedTask();
    }
}
