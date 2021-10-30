using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Accounts
{
    public class TransactionRecord : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public int TransDefinationdCode { get; set; }
        public decimal? AmountLocal { get; set; }
        public decimal? AmountForex { get; set; }

        [StringLength(1)]
        public string RefType { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(250)]
        public string Narration { get; set; }

        [ForeignKey("TransDefinationdCode")]
        public virtual TransDefination TransDefination { get; set; }
    }
}