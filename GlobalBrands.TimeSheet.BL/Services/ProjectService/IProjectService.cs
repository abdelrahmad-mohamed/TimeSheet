using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.BL.DTOS.EmployeeDTOS;
using GlobalBrands.TimeSheet.BL.DTOS.ProjectDTOS;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.BL.Services.ProjectService
{
    public interface IProjectService
    {
        public Task<IEnumerable<Project>> GetAll();

        public Task<Project?> GetById(int id);

        public Task<int> Add(CreateProjectDTO project);

        public Task<int> Update(UpdateProjectDTO project);

        public Task<int> Delete(Project employee);
    }
}
