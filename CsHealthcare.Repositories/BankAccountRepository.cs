using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Entity.Accounts;

namespace CsHealthcare.Repositories
{
    public class BankAccountRepository : Repository<BankAccount>
    {
        public BankAccountRepository(AppDbContext context) : base(context)
        {

        }
    }
}
