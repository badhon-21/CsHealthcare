using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Stock;

namespace CsHealthcare.Repositories
{
    public class DrugStockDetailsRepository:Repository<DrugStockDetails>
    {
        public DrugStockDetailsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
