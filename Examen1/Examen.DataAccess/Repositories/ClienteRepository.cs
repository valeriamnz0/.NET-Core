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
    public class ClienteRepository : Repository<Cliente>, IRepository<Cliente>
    {
        public ClienteRepository(ApplicationDbContext context)
            : base(context)
        {

        }

    }
}
