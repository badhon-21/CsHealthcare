using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Doctor;

namespace CsHealthcare.Repositories
{
   
    public class VisitDiscountRepository : Repository<VisitDiscount>
    {
        public VisitDiscountRepository(AppDbContext context) : base(context)
        {

        }
    }
}
