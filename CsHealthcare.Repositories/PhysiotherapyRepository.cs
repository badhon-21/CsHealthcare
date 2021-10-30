using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Physiotherapy;

namespace CsHealthcare.Repositories
{
    public class PhysiotherapyRepository:Repository<Physiotherapy>
    {
        public PhysiotherapyRepository(AppDbContext context) : base(context)
        {

        }
    }
}
