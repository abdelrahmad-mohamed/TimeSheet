using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBrands.TimeSheet.DAL.Common;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities
{
    public class ETask
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

       
        public string Description { get; set; } = null!;

        [NotMapped]
        public double NoOfHours => (EndDate - StartDate).TotalHours;

        public DateTime StartDate { get; set; }

       
        public DateTime EndDate { get; set; }

        
        public DateTime? CompleteTask { get; set; }

        public Status Status { get; set; }


        /*Navigation Property*/

        public virtual Employee Employee { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;





        /*Foreign key*/
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
    }
}
