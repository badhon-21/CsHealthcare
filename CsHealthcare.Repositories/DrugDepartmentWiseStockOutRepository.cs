using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.Repositories
{
    public class DrugDepartmentWiseStockOutRepository:Repository<DrugDepartmentWiseStockOut>
    {
        public DrugDepartmentWiseStockOutRepository(AppDbContext context) : base(context)
        {
        }
    }
}
