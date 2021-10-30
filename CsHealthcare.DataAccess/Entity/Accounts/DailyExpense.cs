using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Accounts
{
   public partial class DailyExpense: AuditableEntity
    {

        [Required]
        [Key]
        public int DeId { get; set; }
        [Required]
        [StringLength(50)]
        public string VoucherNo { get; set; }
        public string TxnNo { get; set; }
        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public string BaId { get; set; }
        public string Purpose{ get; set; }
        public string RecievedBy { get; set; }
     
    }
}
