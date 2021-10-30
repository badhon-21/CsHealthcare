using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{
      public class MsDialysisAmountPurposeRepository : Repository<MsDialysisAmountPurpose>
     {
        public MsDialysisAmountPurposeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
