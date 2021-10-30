using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Packages;

namespace CsHealthcare.Repositories
{
    public class BillingForCheckupPackageDetailsRepository:Repository<BillingForCheckupPackageDetails>
    {
      public  BillingForCheckupPackageDetailsRepository(AppDbContext context) : base(context)
        {
            
        }

    }
}
