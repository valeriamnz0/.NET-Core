using Examen.Models.DataModels;
using Examen.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.DataAccess.Data
{
    public class ApplicationDbContext : /*DbContext*/ IdentityDbContext<IdentityUser>, IApplicationDbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

    }
}
