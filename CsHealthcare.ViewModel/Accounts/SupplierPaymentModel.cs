using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Accounts
{
   public class SupplierPaymentModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Open Date")]
        public DateTime? OpenDate { get; set; }
        [Display(Name = "Check Number")]
        public string CheckNumber { get; set; }
        [Display(Name = "Check Date")]
        public DateTime? CheckDate { get; set; }

        //[Display(Name = "Narration")]
        //public string Narration { get; set; }
        [Display(Name = "Trans No")]
        public string TransNo { get; set; }
        [Display(Name = "Trans Date")]
        public DateTime? TransDate { get; set; }
        [Display(Name = "Trans Type")]
        public string TransType { get; set; }
        [Display(Name = "Received By")]
        public string ReceivedBy { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

    }
}
