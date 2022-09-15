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
    public class RolRepository : Repository<Rol>, IRepository<Rol>
    {
        public RolRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
