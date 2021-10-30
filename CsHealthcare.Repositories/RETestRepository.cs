using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.Repositories
{
   public class RETestRepository:Repository<RETest>
   {
       public RETestRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
