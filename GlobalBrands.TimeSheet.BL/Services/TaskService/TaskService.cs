using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
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

        public async Task<IEnumerable<GetAllTaskDTO>> GetAll()
        {
            var tasks=await taskRepository.GetAllAsync();
            var taskEntity = tasks.Select(t => new GetAllTaskDTO()
            {
                Id = t.Id,
                TaskName = t.Title,
                ProjectName = t.Project.Name,
                EmployeeName = t.Employee.Name,
                Hours = t.NoOfHours,
                Status = t.Status.ToString()
            }).ToList();

            return taskEntity;
           

           
        }

        public async Task<EmployeeTaskDTO> GetById(int id)
        {
            if (id <= 0)
                return null;
            var employeeTask= await taskRepository.GetByIdAsync(id);
            var taskEntity = new EmployeeTaskDTO
            {
                Id = employeeTask.Id,
                TaskName = employeeTask.Title,
                Description = employeeTask.Description,
                ProjectName = employeeTask.Project.Name,
                ProjectId = employeeTask.ProjectId,
                StartDate = employeeTask.StartDate,
                EndDate = employeeTask.EndDate,
                Status = employeeTask.Status.ToString()
            };
            return taskEntity;
        }
        public async Task<(bool success,string Message)> Add(EmployeeTaskDTO task)
        {

            var currentTime = DateTime.Now;
            currentTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, currentTime.Minute, 0);

            if (task.StartDate < currentTime || task.EndDate < currentTime || task.StartDate >= task.EndDate)
            {
                string Message = "";

                if (task.StartDate < currentTime)
                    Message += "Start Date cannot be in the past.\n";

                if (task.EndDate < currentTime)
                    Message += "End Date cannot be in the past.\n";

                if (task.StartDate >= task.EndDate)
                    Message += "Start Date must be before End Date.\n";

                return (false, Message);
            }



            var taskEntity = new ETask()
            {
                Id = task.Id,
                Title = task.TaskName,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = (Status)Enum.Parse(typeof(Status), task.Status),
                ProjectId = task.ProjectId,
                EmployeeId = task.EmployeeId
            };
            var result = await taskRepository.AddAsync(taskEntity);
            return result > 0
                 ? (true, null)
                : (false, "Failed to add task.");


        }

        public async Task<(bool success, string Message)> Update(EmployeeTaskDTO task)
        {
            
            var currentTime = DateTime.Now;
            currentTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, currentTime.Minute, 0);

          
            if (task.StartDate < currentTime || task.EndDate < currentTime || task.StartDate >= task.EndDate)
            {
                string Message = "";

                if (task.StartDate < currentTime)
                    Message += "Start Date cannot be in the past.\n";

                if (task.EndDate < currentTime)
                    Message += "End Date cannot be in the past.\n";

                if (task.StartDate >= task.EndDate)
                    Message += "Start Date must be before End Date.\n";

                return (false, Message);
            }

           
            var existingTask = await taskRepository.GetByIdAsync(task.Id);
            if (existingTask == null)
                return (false, "Task not found.");

            
            existingTask.Title = task.TaskName;
            existingTask.Description = task.Description;
            existingTask.Status = (Status)Enum.Parse(typeof(Status), task.Status);

           
            existingTask.EndDate = task.EndDate;

           
            var result = await taskRepository.UpdateAsync(existingTask);

            return result > 0
                ? (true, "Task updated successfully.")
                : (false, "Failed to update task.");
        }

        public async Task<int> Delete(EmployeeTaskDTO task)
        {

            var TaskEmployeeDTO = new ETask()
            {
                Id=task.Id,
                Title = task.TaskName,
                Description = task.Description,
                ProjectId = task.ProjectId,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = (Status)Enum.Parse(typeof(Status), task.Status)

            };


            var result = await taskRepository.DeleteAsync(TaskEmployeeDTO);
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

        public async Task<IEnumerable<ETask>> GetTasksByProjectId(int id) { 
        var tasks = await taskRepository.GetTasksByProjectId(id);
            if(tasks==null)
                return Enumerable.Empty<ETask>();
            return tasks;
        }
    }
}