using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entity.Master;

namespace CsHealthcare.Repositories
{

    public class EducationRepository : Repository<Education>
    {
        public EducationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
