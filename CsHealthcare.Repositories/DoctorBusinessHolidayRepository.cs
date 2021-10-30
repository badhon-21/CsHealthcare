using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.Repositories
{
    
   public class DoctorBusinessHolidayRepository : Repository<DoctorBusinessHoliday>
    {
        public DoctorBusinessHolidayRepository(AppDbContext context) : base(context)
        {

        }
    }
}
