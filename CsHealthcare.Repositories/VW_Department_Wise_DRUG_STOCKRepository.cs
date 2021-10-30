using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Views;

namespace CsHealthcare.Repositories
{
    public class VW_Department_Wise_DRUG_STOCKRepository:Repository<VW_Department_Wise_DRUG_STOCK>
    {
        public VW_Department_Wise_DRUG_STOCKRepository(AppDbContext context) : base(context)
        {
        }
    }
}
