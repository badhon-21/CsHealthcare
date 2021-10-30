using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.EmployeeLoan;

namespace CsHealthcare.Repositories
{
    public class LoanConfigPlanRepository : Repository<loanConfigPlan>
    {
        public LoanConfigPlanRepository(AppDbContext context) : base(context)
        {

        }

    }
}
