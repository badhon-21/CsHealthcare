using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Stock;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugDailyStockHistory : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int? DrugStockInId { get; set; }
        public int? DrugId { get; set; }
        public decimal? DisbusQty { get; set; }
        public decimal? RemQty { get; set; }

        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }

        [ForeignKey("DrugStockInId")]
        public virtual DrugStockIn DrugStockIn { get; set; }
    }
}