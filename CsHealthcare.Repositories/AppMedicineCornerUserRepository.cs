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

     public class AppMedicineCornerUserRepository : Repository<AppMedicineCornerUser>
    {
        public AppMedicineCornerUserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
