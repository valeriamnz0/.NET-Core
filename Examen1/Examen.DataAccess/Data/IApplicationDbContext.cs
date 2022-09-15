using Examen.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.DataAccess.Data
{
    public interface IApplicationDbContext
    {

        DbSet<Rol> Roles { get; set; }

        DbSet<Empleado> Empleados { get; set; }

        DbSet<Cliente> Clientes { get; set; }
    }
}
