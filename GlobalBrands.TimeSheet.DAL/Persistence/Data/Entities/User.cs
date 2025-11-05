using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GlobalBrands.TimeSheet.DAL.Persistence.Data.Entities
{
    public class User:IdentityUser
    {
        

        public string? Address { get; set; } = null!;

        public Employee Employee { get; set; } = null!;

    }
}
