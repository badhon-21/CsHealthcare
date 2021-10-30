using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Accounts
{
    public class CashItemModel
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Items")]
        public string items { get; set; }

        [Display(Name = "Particulars")]
        public string particulars { get; set; }

        [Display(Name = "Amount")]
        public decimal amount { get; set; }
        public decimal total { get; set; }
    }

    public class CashInsertModel
    {

        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }

        [Display(Name = "Date")]
        public DateTime TransDate { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

    }
    public class PettyCashModel
    {
        [Display(Name = "Voucher No")]
        public string VoucherNo { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Date")]
        public DateTime TransDate { get; set; }

    }
}
