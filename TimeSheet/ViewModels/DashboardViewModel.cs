using GlobalBrands.TimeSheet.BL.DTOS.TaskDTOS;
using GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities;

namespace GlobalBrands.TimeSheet.PL.ViewModels
{
    public class DashboardViewModel
    {
        public List<TaskStatusDTO> DashboardCard { get; set; }
        public List<TaskHoursDTO> TaskPerHour { get; set; }
        public List<TaskTrendDTO> TaskDailyTrend { get; set; }


    }
}
