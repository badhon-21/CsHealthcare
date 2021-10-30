using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.Repositories
{
   
     public class PatientAllergyInformationRepository : Repository<PatientAllergyInformation>
    {
        public PatientAllergyInformationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
