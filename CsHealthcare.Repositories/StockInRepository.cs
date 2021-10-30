using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Store;

namespace CsHealthcare.Repositories
{
   public class StockInRepository:Repository<StockIn>
   {
       public StockInRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
