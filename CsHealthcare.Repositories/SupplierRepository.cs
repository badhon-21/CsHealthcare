using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Accounts;

namespace CsHealthcare.Repositories
{
    public class SupplierRepository:Repository<Supplier>
    {
        public SupplierRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
