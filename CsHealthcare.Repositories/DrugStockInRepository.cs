using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Stock;

namespace CsHealthcare.Repositories
{
    public class DrugStockInRepository:Repository<DrugStockIn>
    {
        public DrugStockInRepository(AppDbContext context) : base(context)
        {
        }
    }
}
