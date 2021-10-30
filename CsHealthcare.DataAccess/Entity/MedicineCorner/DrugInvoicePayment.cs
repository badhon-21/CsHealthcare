using System;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugInvoicePayment : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string LotId { get; set; }

        [StringLength(50)]
        public string TxnId { get; set; }

        public DateTime? TxmDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? RemAmount { get; set; }

        [StringLength(10)]
        public string PayType { get; set; }

        [StringLength(50)]
        public string ChequeNo { get; set; }

        public DateTime? ChequeDate { get; set; }

        [StringLength(50)]
        public string BankAccount { get; set; }

        [StringLength(80)]
        public string ReceiveBy { get; set; }
        
    }
}