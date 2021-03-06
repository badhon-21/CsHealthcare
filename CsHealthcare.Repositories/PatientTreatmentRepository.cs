using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{
   
    public class PatientTreatmentRepository : Repository<PatientTreatment>
    {
        public PatientTreatmentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
