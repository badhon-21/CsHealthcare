using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entities.Doctor;
using CsHealthcare.DataAccess.Entities.Hospital;

namespace CsHealthcare.Repositories
{
    
     public class HospitalInformationRepository : Repository<HospitalInformation>
    {
        public HospitalInformationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
