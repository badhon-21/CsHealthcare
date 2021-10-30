using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.EmployeeLoan
{
    public class LoanConfigPlanModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Loan Code")]

        public int LoanConfigId { get; set; }
        [Display(Name = "Strat Amount")]
        public decimal StratAmount { get; set; }
        [Display(Name = "End Amount")]
        public decimal EndAmount { get; set; }
        [Display(Name = "No of Installment")]
        public int NumberofInstallment { get; set; }
        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }
    }
}
