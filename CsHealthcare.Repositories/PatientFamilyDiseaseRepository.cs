using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entities.Patient;

namespace CsHealthcare.Repositories
{
   
     public class PatientFamilyDiseaseRepository : Repository<PatientFamilyDisease>
    {
        public PatientFamilyDiseaseRepository(AppDbContext context) : base(context)
        {

        }
    }
}
