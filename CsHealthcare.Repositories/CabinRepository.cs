using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Cabin;

namespace CsHealthcare.Repositories
{
   public class CabinRepository:Repository<Cabin>
   {
       public CabinRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
