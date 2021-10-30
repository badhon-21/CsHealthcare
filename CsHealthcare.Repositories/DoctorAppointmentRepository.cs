using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.Repositories
{

    public class DoctorAppointmentRepository : Repository<DoctorAppointment>
    {
        public DoctorAppointmentRepository(AppDbContext context) : base(context)
        {

        }
    }
}