using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.HumanResource;

namespace CsHealthcare.DataAccess.Entity.Store
{
   public partial class StockOutItem
    {

        public StockOutItem()
        {

            StockOutDetails = new HashSet<StockOutDetails>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string MemoNo { get; set; }

        [StringLength(50)]
        public string TxnNo { get; set; }

        [StringLength(50)]
        public string LotId { get; set; }
       
        public string DepartmentId { get; set; }
        [StringLength(30)]
        public string IssuedFor  { get; set; }
        public decimal? TotalQty { get; set; }
        public decimal? StocOutQty { get; set; }
        public decimal? Amount { get; set; }
        [StringLength(50)]
        public string RecivedBy { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<StockOutDetails> StockOutDetails { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DEPARTMENT Department { get; set; }
    }
}
