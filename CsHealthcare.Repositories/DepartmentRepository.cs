using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.HumanResource;

namespace CsHealthcare.Repositories
{
    public class DepartmentRepository : Repository<DEPARTMENT>
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
