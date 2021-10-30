using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Entity.Stock;

namespace CsHealthcare.DataAccess.Entity.Store
{
   public partial class StockIn:AuditableEntity
    {
        public StockIn()
        {

            StockInDetails = new HashSet<StockInDetails>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string TxnNo { get; set; }

        [Required]
        [StringLength(50)]
        public string LotId { get; set; }

        //public int StoreItemId { get; set; }

        [Required]
        [StringLength(50)]
        public string InvNo { get; set; }

        [StringLength(50)]
        public string DpoId { get; set; }
        public decimal Price { get; set; }

        public decimal InvAmount { get; set; }

        public decimal InvQty { get; set; }

        public DateTime InvDate { get; set; }

        public DateTime? RecordDate { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string PaymentStatus { get; set; }

 
        //[ForeignKey("StoreItemId")]
        //public virtual StoreItem StoreItem { get; set; }

        public virtual ICollection<StockInDetails> StockInDetails { get; set; }

    }
}
