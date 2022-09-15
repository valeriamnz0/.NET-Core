using Examen.DataAccess.Data;
using Examen.DataAccess.Repository;
using Examen.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.DataAccess.Repositories
{
    public class EmpleadoRepository : Repository<Empleado>, IRepository<Empleado>
    {

        public EmpleadoRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
