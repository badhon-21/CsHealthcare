using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Accounts
{
    public class LcModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "LC No")]
        public int LCNo { get; set; }
        [Display(Name = "Issue Date")]
        public DateTime? IssueDate { get; set; }
        [Display(Name = "Beneficiary Name")]
        public string BeneficiayName { get; set; }
        [Display(Name = "Origin")]
        public string Origin { get; set; }
        [Display(Name = "Item")]
        public string Item { get; set; }

        [Display(Name = "Quantity")]
        public string Quantity { get; set; }

        [Display(Name = "Tenor")]
        public string Tenor { get; set; }
        [Display(Name = "LC Value")]
        public decimal LCValue { get; set; }
        [Display(Name = "Currency Type")]
        public int CurrencyTypeId { get; set; }
        [Display(Name = "Port")]
        public string Port { get; set; }
        [Display(Name = "Ship Date")]
        public DateTime? ShipDate { get; set; }

        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        [Display(Name = "Invoice Value")]
        public decimal InvoiceValue { get; set; }
        [Display(Name = "Invoice CurrencyType ")]
        public int InvoiceCurrencyTypeId { get; set; }
        [Display(Name = "BL No")]
        public string BLNo { get; set; }
        [Display(Name = "Ship Qty")]
        public string ShipQty { get; set; }
        [Display(Name = "ETA/CTG")]
        public DateTime? ETA { get; set; }
        [Display(Name = "Paid On")]
        public DateTime? PaidOn { get; set; }
        [Display(Name = "U-Pass Due")]
        public DateTime? UPassDue { get; set; }
        [Display(Name = "Rmks")]
        public string Rmks { get; set; }


    }


    public class LCSummaryModel
    {
       
        public DateTime? IssueDate { get; set; }
        public int LCNo { get; set; }
        public string Supplier { get; set; }

        public string Item { get; set; }

        public decimal LCValue { get; set; }
        public int CurrencyTypeId { get; set; }
        public string Port { get; set; }
        public string Rmks { get; set; }
        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }
    }

    public class LCViewModel
    {

        public DateTime? IssueDate { get; set; }
        public int LCNo { get; set; }
        public string Supplier { get; set; }

        public string Item { get; set; }

        public decimal LCValue { get; set; }
        public string Port { get; set; }
        public string Rmks { get; set; }
        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }
    }

}
