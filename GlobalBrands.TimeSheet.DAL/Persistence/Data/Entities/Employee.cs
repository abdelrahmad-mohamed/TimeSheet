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

        [EmailAddress (ErrorMessage = "Invalid email format")]

        public string Email { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid Phone format")]
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Position { get; set; } = null!;
        public DateTime HireDate { get; set; }

        [DataType(DataType.Currency)]
        [Range(100,double.MaxValue, ErrorMessage = "Salary must be more than 100")]
        public decimal Salary { get; set; }

        public int? AzureObjectId { get; set; }

        /* Navigation property */
        public virtual ICollection<ETask> Tasks { get; set; } = new HashSet<ETask>();





    }
}
