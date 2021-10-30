using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Hospital;
using CsHealthcare.DataAccess.Entity.Views;

namespace CsHealthcare.Repositories
{
   public class VwDrugStocksRepository : Repository<VW_DRUG_STOCK>
   {
       public VwDrugStocksRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
