using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{
   
     public class DrugDurationRepository : Repository<DrugDuration>
    {
        public DrugDurationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
