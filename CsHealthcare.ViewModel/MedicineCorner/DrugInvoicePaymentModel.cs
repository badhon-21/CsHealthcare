using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
  public  class DrugInvoicePaymentModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Lot Id")]
        public string LotId { get; set; }

        [Display(Name = "Txn Id")]
        public string TxnId{ get; set; }
        [Display(Name = "Txn No")]
        public string TxnNo { get; set; }

        [Display(Name = "Txn Date")]
        public DateTime? TxnDate { get; set; }

        [Display(Name = "Payment Amount")]
        public decimal? PaymentAmount { get; set; }

        [Display(Name = "Remaining Amount")]
        public decimal? RemAmount { get; set; }

        [Display(Name = "Pay Type")]
        public string PayType { get; set; }

        [Display(Name = "Cheque No")]
        public string ChequeNo { get; set; }

        [Display(Name = "Cheque Date")]
        public DateTime? ChequeDate { get; set; }

        [Display(Name = "Bank Account")]
        public string BankAccount { get; set; }

        [Display(Name = "Receive By")]
        public string ReceiveBy { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }


    }
}
