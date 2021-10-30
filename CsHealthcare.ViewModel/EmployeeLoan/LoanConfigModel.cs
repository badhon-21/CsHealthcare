using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.EmployeeLoan
{
    public class LoanConfigModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Loan Code")]
        public string Code { get; set; }
        [Display(Name = "Title")]
        public string LoanTitle { get; set; }
        [Display(Name = "Notes")]
        public string Note { get; set; }
        [Display(Name = "Is Based On Salary")]
        public bool IsbasedOnSalary { get; set; }
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

    }
}
