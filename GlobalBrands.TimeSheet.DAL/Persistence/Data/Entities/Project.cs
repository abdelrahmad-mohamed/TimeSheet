using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Description must be in range (2 => 50) character", MinimumLength = 2)]
        public string Description { get; set; } = null!;

        public DateTime DateTime { get; set; }

        /*Navigation property*/
        public virtual ICollection<ETask> Tasks { get; set; } = new HashSet<ETask>();

        
    }
}
