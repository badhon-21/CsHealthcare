using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public partial class PurchaseOrder:AuditableEntity
    {
        public PurchaseOrder()
        {

            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }
        [Key]
        public int Id { get; set; }
        public int DRUG_MANUFACTURERId { get; set; }
        [StringLength(50)]
        public string MemoNo { get; set; }

        [StringLength(50)]
        public string TxnNo { get; set; }

        [StringLength(50)]
        public string LotId { get; set; }

        public decimal TotalQty { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime RecordDate { get; set; }

        [ForeignKey("DRUG_MANUFACTURERId")]
        public virtual DRUG_MANUFACTURER DRUG_MANUFACTURER { get; set; }


        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
