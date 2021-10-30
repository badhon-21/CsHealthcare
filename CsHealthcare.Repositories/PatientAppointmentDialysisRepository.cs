using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Diagnostic;
using CsHealthcare.DataAccess.Dialysis;
namespace CsHealthcare.Repositories
{
  public class PatientAppointmentDialysisRepository : Repository<PatientAppointmentDialysis>
  {
      public PatientAppointmentDialysisRepository(AppDbContext context) : base(context)
      {
          
      }
    }
}
