using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.Repositories
{
    public class PurchaseOrderDetailsRepository:Repository<PurchaseOrderDetails>
    {
        public PurchaseOrderDetailsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
