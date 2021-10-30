using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Packages;

namespace CsHealthcare.Repositories
{
    public class PackageRepository:Repository<Package>
    {
        public PackageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
