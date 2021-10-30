using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;

using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Migrations;

namespace CsHealthcare.Repositories
{
    public class LCRepository : Repository<LC>
    {
        public LCRepository(AppDbContext context) : base(context)
        {

        }
    }
}
