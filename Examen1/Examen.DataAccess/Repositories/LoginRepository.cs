using Examen.DataAccess.Data;
using Examen.DataAccess.Repository;
using Examen.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.DataAccess.Repositories
{
    public class LoginRepository : Repository<LoginInputModel>, IRepository<LoginInputModel>
    {

        public LoginRepository (ApplicationDbContext context)
            : base(context)
        {

        }
    } 
}
