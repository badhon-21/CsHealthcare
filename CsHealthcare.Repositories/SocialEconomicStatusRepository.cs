using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{
   
     public class SocialEconomicStatusRepository : Repository<SocialEconomicStatus>
    {
        public SocialEconomicStatusRepository(AppDbContext context) : base(context)
        {

        }
    }
}
