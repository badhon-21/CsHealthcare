using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.Repositories
{

    public class EmergencyContactRepository : Repository<EmergencyContact>
    {
        public EmergencyContactRepository(AppDbContext context) : base(context)
        {

        }
    }
}
