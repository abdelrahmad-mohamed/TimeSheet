using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
using GlobalBrands.TimeSheet.BL.DTOS.ProjectDTOS;
using GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.Services.TaskService
{
    public interface ITaskService
    {
        public Task<IEnumerable<GetAllTaskDTO>> GetAll();

        public Task<EmployeeTaskDTO> GetById(int id);

        public Task<(bool success,string Message)> Add(EmployeeTaskDTO task);

        public Task<(bool success, string Message)> Update(EmployeeTaskDTO task);

        public Task<int> Delete(EmployeeTaskDTO task);

        public Task<List<TaskStatusDTO>> GetTaskStatusCount();

        public Task<List<TaskHoursDTO>> GetTaskHoursCount();

        public Task<List<TaskTrendDTO>> GetDailyCompletedTask();

        public Task<IEnumerable<ETask>> GetTasksByProjectId(int id);
    }
}
