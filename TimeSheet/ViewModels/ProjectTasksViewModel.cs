using GlobalBrands.TimeSheet.DAL.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalBrands.TimeSheet.PL.ViewModels
{
    public class ProjectTasksViewModel
    {

        public string Title { get; set; } = null!;


        public string Description { get; set; } = null!;


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }



        public Status Status { get; set; }

    }
}
