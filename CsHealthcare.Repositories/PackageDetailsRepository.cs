using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Packages;

namespace CsHealthcare.Repositories
{
    public class PackageDetailsRepository:Repository<PackageDetails>
    {
        public PackageDetailsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
