using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Register_login.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string fullname{ get; set; }
    }
}
