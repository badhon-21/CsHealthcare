using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.Repositories
{
    public class InPatientDischargeDueCollectionRepository:Repository<InPatientDischargeDueCollection>
    {
        public InPatientDischargeDueCollectionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
