using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Accounts
{
    public partial class BankTransaction
    {
        [Required]
        [Key]
        public int BTR_ID { get; set; }
        [Required]
        public int BTR_BA_ID { get; set; }
        [StringLength(100)]
        public string BTR_BA_CODE { get; set; }
        [StringLength(100)]
        public string BTR_BA_ACCOUNT_NAME { get; set; }
        [StringLength(50)]
        public string BTR_TXN_NO { get; set; }
        [StringLength(2)]
        public string BTR_PAY_TYPE { get; set; }

        public decimal BTR_AMOUNT { get; set; }
        public DateTime BTR_TRANS_DATE { get; set; }
        [StringLength(250)]
        public string BTR_NARATION { get; set; }
        [StringLength(1)]
        public string BTR_REC_STATUS { get; set; }
        [StringLength(50)]
        public string BTR_REC_USER { get; set; }
        public DateTime BTR_REC_DATE { get; set; }
    }
}
