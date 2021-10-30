using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;

namespace CsHealthcare.Repositories
{
    
     public class DiseaseConditionRepository : Repository<DiseaseCondition>
    {
        public DiseaseConditionRepository(AppDbContext context) : base(context)
        {

        }
    }
}
