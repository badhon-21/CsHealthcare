using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.DataAccess.Entity.Store
{
   public partial class StoreRequisitionDetails
    {
        [Key]
        public int Id { get; set; }

        public string StoreRequsitionId { get; set; }

        public int StoreItemId { get; set; }
        [StringLength(100)]
        public string StoreItemName { get; set; }
       
        public int Quantity { get; set; }
        [ForeignKey("StoreRequsitionId")]
        public virtual StoreRequisition StoreRequisition { get; set; }

    }
}
