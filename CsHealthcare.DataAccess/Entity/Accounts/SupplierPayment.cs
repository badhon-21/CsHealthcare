using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Accounts
{
   public partial class SupplierPayment:AuditableEntity
    {
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string SI_CODE { get; set; }
        [StringLength(50)]
        public string InvoiceNo{ get; set; }
        public decimal Amount { get; set; }
     
        public DateTime? OpenDate{ get; set; }
        [StringLength(50)]
        public string CheckNumber { get; set; }

        public DateTime? CheckDate { get; set; }

        //[StringLength(200)]
        //public string Narration { get; set; }
        [StringLength(30)]
        public string TransNo { get; set; }
        public DateTime? TransDate { get; set; }
        [StringLength(2)]
        public string TransType { get; set; }
        [StringLength(100)]
        public string ReceivedBy { get; set; }

        [ForeignKey("SI_CODE")]
        public virtual Supplier Supplier { get; set; }
    }
}
