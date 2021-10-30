using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugSaleReturn : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MemoNo { get; set; }

        [Required]
        [StringLength(50)]
        public string LotNo { get; set; }

        public int DrugId { get; set; }
        public decimal ReturnPrice { get; set; }
        public decimal ReturnDiscount { get; set; }
        public decimal ReturnQty { get; set; }
        public decimal ReturnSubTotal { get; set; }
        public DateTime ReturnDate { get; set; }

        [Required]
        [StringLength(50)]
        public string TxnNo { get; set; }

        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }
    }
}