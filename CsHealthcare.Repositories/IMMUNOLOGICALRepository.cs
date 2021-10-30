using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.Repositories
{
   public  class IMMUNOLOGICALRepository:Repository<IMMUNOLOGICAL>
   {
       public IMMUNOLOGICALRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
