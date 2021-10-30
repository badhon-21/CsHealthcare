using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Packages;

namespace CsHealthcare.Repositories
{
   public  class BillingForCheckupPackageRepository:Repository<BillingForCheckupPackage>
   {
       public BillingForCheckupPackageRepository(AppDbContext context) : base(context)
       {
           
       }
    }
}
