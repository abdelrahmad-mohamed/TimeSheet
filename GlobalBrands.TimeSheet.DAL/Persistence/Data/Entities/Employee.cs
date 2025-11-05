using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string? PhoneNumber { get; set; } = null!;

        public string? Address { get; set; } = null!;



        /* Navigation property */
        public virtual ICollection<ETask> Tasks { get; set; } = new HashSet<ETask>();


        public User User { get; set; } = null!;

        /*Foreign key*/

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; } = null!;


    }
}
