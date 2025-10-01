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

        public string Description { get; set; } = null!;

        public DateTime DateTime { get; set; }

        /*Navigation property*/
        public virtual ICollection<ETask> Tasks { get; set; } = new HashSet<ETask>();

        
    }
}
