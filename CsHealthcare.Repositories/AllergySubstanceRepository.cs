using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.Repositories
{
    

    public class AllergySubstanceRepository : Repository<AllergySubstance>
    {
        public AllergySubstanceRepository(AppDbContext context) : base(context)
        {

        }
    }
}
