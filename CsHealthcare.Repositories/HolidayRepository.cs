using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.Repositories
{
    public class HolidayRepository:Repository<Holiday>
    {
        public HolidayRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
