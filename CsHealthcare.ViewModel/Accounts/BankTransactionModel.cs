using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Accounts
{
    public class BankTransactionModel
    {
        [Display(Name = "ID")]
        public int BTR_ID { get; set; }

        [Display(Name = "Bank Account ID")]
        public int BTR_BA_ID { get; set; }

        [Display(Name = "Bank Account Code")]
        public string BTR_BA_CODE { get; set; }
        [Display(Name = "NAME")]
        public string BTR_BA_ACCOUNT_NAME { get; set; }
        [Display(Name = "Transaction NO")]
        public string BTR_TXN_NO { get; set; }
        [Display(Name = "Payment Type")]
        public string BTR_PAY_TYPE { get; set; }
        [Display(Name = "Amount")]
        public decimal BTR_AMOUNT { get; set; }
        [Display(Name = "Transaction Date")]
        public DateTime BTR_TRANS_DATE { get; set; }
        [Display(Name = "Narration")]
        public string BTR_NARATION { get; set; }
        [Display(Name = "BTR_REC_STATUS")]
        public string BTR_REC_STATUS { get; set; }
        [Display(Name = "BTR_REC_USER")]
        public string BTR_REC_USER { get; set; }
        [Display(Name = "BTR_REC_DATE")]
        public DateTime BTR_REC_DATE { get; set; }
    }
}
