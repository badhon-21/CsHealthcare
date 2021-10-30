using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Dialysis;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.Repositories
{
  public class PatientDialysisRepository : Repository<PatientDialysis>
  {
      public PatientDialysisRepository(AppDbContext context) : base(context)
      {
          
      }
    }
}
