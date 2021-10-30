using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{

    public class AppUserRepository : Repository<AppUser>
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
