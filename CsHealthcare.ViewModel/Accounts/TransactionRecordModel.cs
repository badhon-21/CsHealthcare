using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Accounts
{
    public class TransactionRecordModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Transaction Defination Code")]
        public int TransDefinationdCode { get; set; }
        
        [Display(Name = "Amount Local")]
        public decimal? AmountLocal { get; set; }

        [Display(Name = "Amount Forex")]
        public decimal? AmountForex { get; set; }

        [Display(Name = "Reference Type")]
        public string RefType { get; set; }

        [Display(Name = "Date")]
        public DateTime? Date { get; set; }

        [Display(Name = "Narration")]
        public string Narration { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
