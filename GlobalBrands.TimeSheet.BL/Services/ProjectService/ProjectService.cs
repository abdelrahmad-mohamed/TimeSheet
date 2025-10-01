using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.ProjectDTOS;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.EmployeeRepository;
using GlobalBrands.TimeSheet.DAL.Persistence.Repositories.ProjectRepository;

namespace GlobalBrands.TimeSheet.BL.Services.ProjectService
{
    public class ProjectService(IProjectRepository projectRepository) : IProjectService
    {
        private readonly IProjectRepository projectRepository = projectRepository;

        public async Task<IEnumerable<Project>> GetAll()
        {
           return await projectRepository.GetAllAsync();
        }

        public async Task<Project?> GetById(int id)
        {
            if (id <= 0)
                return null;
            return await projectRepository.GetByIdAsync(id);
        }
        public async Task<int> Add(CreateProjectDTO project)
        {
            var projectEntity = new Project()
            {
                Name = project.Name,
                Description = project.Description,
                DateTime = project.DateTime,
            };
            var result = await projectRepository.AddAsync(projectEntity);
            return result > 0 ? result : 0;


        }

        public async Task<int> Update(UpdateProjectDTO project)
        {
            var existingProject = projectRepository.GetByIdAsync(project.Id);
            if (existingProject == null)
            { return 0; }

            var projectEntity = new Project()
            {
                Name = project.Name,
                Description = project.Description,
                DateTime = project.DateTime,

            };
            var result = await projectRepository.UpdateAsync(projectEntity);
            return result > 0 ? result : 0;
        }

        public async Task<int> Delete(Project project)
        {
            var existingProject =await projectRepository.GetByIdAsync(project.Id);
            if (existingProject == null)
             return 0; 

          
            var result = await projectRepository.DeleteAsync(existingProject);
            return result > 0 ? result : 0;


        }




    }
}
