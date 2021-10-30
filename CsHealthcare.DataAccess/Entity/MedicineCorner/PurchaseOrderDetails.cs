using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public partial class PurchaseOrderDetails
    {
        [Key]
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int DrugId { get; set; }

        [StringLength(80)]
        public string DrugUnitStrength { get; set; }


        public string DrugPresentationType { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? SubTotalPrice { get; set; }
        public decimal? Discount { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey("DrugId")]
        public virtual DRUG DRUG { get; set; }
    }
}
