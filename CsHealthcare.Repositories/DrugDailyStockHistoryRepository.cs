using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.Repositories
{
 
      public class DrugDailyStockHistoryRepository : Repository<DrugDailyStockHistory>
    {
        public DrugDailyStockHistoryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
