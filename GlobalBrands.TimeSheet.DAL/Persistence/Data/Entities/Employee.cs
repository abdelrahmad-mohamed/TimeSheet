using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public decimal Salary { get; set; }

        public int? AzureObjectId { get; set; }

        /* Navigation property */
        public virtual ICollection<ETask> Tasks { get; set; } = new HashSet<ETask>();





    }
}
