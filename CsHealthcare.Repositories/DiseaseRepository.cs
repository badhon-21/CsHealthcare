using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.Repositories
{
    
    public class DiseaseRepository : Repository<Disease>
    {
        public DiseaseRepository(AppDbContext context) : base(context)
        {

        }
    }
}
