using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.ProjectDTOS;
using GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS;
using GlobalBrands.TimeSheet.BL.Services.ProjectService;
using GlobalBrands.TimeSheet.DAL.Common;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.EmployeeRepository;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.ProjectRepository;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.TaskRepository;

namespace GlobalBrands.TimeSheet.BL.Services.TaskService
{
    public class TaskService(ITaskRepository taskRepository,IEmployeeRepository employeeRepository):ITaskService
    {
        private readonly ITaskRepository taskRepository = taskRepository;
        private readonly IEmployeeRepository employeeRepository = employeeRepository;

        public async Task<IEnumerable<ETask>> GetAll()
        {
            return await taskRepository.GetAllAsync();
        }

        public async Task<ETask?> GetById(int id)
        {
            if (id <= 0)
                return null;
            return await taskRepository.GetByIdAsync(id);
        }
        public async Task<int> Add(CreateTaskDTO task)
        {
            var taskEntity = new ETask()
            {
                Title = task.Title,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate
            };
            var result = await taskRepository.AddAsync(taskEntity);
            return result > 0 ? result : 0;


        }

        public async Task<int> Update(UpdateTaskDTO task)
        {
            var existingTask = taskRepository.GetByIdAsync(task.Id);
            if (existingTask == null)
             return 0;

            var taskEntity = new ETask()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
               EndDate=task.EndDate,

            };
            var result = await taskRepository.UpdateAsync(taskEntity);
            return result > 0 ? result : 0;
        }

        public async Task<int> Delete(ETask task)
        {
            var existingTask = await taskRepository.GetByIdAsync(task.Id);
            if (existingTask == null)
                return 0;


            var result = await taskRepository.DeleteAsync(existingTask);
            return result > 0 ? result : 0;
        }

        public async Task<List<TaskStatusDTO>> GetTaskStatusCount() { 
        
            var employee= await employeeRepository.GetAllAsync();
            var employeeCount=employee.Count();

            var task = await taskRepository.GetAllAsync();

            var statusCountPerTask=task.GroupBy(e=>e.Status)
                .Select(g => new TaskStatusDTO { Status = g.Key , TaskCount = g.Count() }).ToList();

            var result =statusCountPerTask.Select(e => new TaskStatusDTO { EmployeeCount = employeeCount, Status =e.Status,TaskCount=e.TaskCount }).ToList();

            return  result;

        }

        public async Task<List<TaskHoursDTO>> GetTaskHoursCount() {
            var employees =await employeeRepository.GetAllAsync();   
            var task = await taskRepository.GetAllAsync();
            var taskHours = task.GroupBy(e => e.EmployeeId)
                .Select(g => new TaskHoursDTO  {EmployeeId=g.Key ,TotalHours = g.Sum(t => t.NoOfHours) }).ToList();

            foreach (var emp in taskHours){
                var employee = employees.FirstOrDefault(e => e.Id == emp.EmployeeId);
                if (employee != null) { 
                     emp.EmployeeName = employee.Name;
                }
            }
            
            return taskHours;
        }

        public async Task<List<TaskTrendDTO>> GetDailyCompletedTask() { 
        
            var task = await taskRepository.GetAllAsync();
            var dailyTrend =  task.Where(t => t.Status ==Status.Completed && t.CompleteTask.HasValue)
                                 .GroupBy(t => t.CompleteTask.Value.Date)
                                 .Select(g => new TaskTrendDTO { Date = g.Key, CompletedCount = g.Count() })
                                 .OrderBy(t=>t.Date)
                                 .ToList();
            return dailyTrend;

        }
    }
}