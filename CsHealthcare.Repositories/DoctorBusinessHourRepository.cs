using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.Repositories
{
 
   public class DoctorBusinessHourRepository : Repository<DoctorBusinessHour>
    {
        public DoctorBusinessHourRepository(AppDbContext context) : base(context)
        {

        }
    }
}
