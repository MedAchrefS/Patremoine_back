using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register_login.Models
{
    public class AuthentificationContext : IdentityDbContext
    {
        public AuthentificationContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<TypePatrimoine> TypePatrimoines { get; set; }

        public DbSet<Direction> Directions { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Residence> Residences { get; set; }

        public DbSet<Patremoine> Patremoines { get; set; }
    }
}
