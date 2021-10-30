using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.Repositories
{
    public class DrugGroupRepository:Repository<DrugGroup>
    {
        public DrugGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
