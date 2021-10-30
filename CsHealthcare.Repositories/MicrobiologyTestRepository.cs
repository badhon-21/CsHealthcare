using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.MicrobiologyTest;

namespace CsHealthcare.Repositories
{
    public class MicrobiologyTestRepository:Repository<MicrobiologyTest>
    {
        public MicrobiologyTestRepository(AppDbContext context) : base(context)
        {
        }
    }
}
