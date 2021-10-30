using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.EmployeeLoan
{
    public class loanConfigPlan
    {

        public int Id { get; set; }
        public int LoanConfigId { get; set; }
        public decimal StartAmount { get; set; }

        public decimal EndAmount { get; set; }

        public int NnumberOfInstalment { get; set; }

        public decimal IterestRate { get; set; }
        public virtual LoanConfig LoanConfig { get; set; }
    }
}
