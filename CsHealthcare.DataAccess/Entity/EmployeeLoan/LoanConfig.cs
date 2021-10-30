using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.DataAccess.Entity.EmployeeLoan
{
    public partial class LoanConfig : AuditableEntity
    {

        public LoanConfig()
        {
            loanConfigPlans = new HashSet<loanConfigPlan>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        [StringLength(100)]
        public string LoanTitle { get; set; }
        [StringLength(100)]
        public string Note { get; set; }

        public bool IsbasedOnSalary { get; set; }
        public virtual ICollection<loanConfigPlan> loanConfigPlans { get; set; }

    }
}
