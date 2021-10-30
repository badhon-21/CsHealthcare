using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
  public partial  class PharmacyRequisitionDetails
    {
        [Key]
        public int Id { get; set; }
      
        public string PharmacyrequsitionId { get; set; }
     
        public int DrugId { get; set; }
        [StringLength(500)]
        public string DrugName{ get; set; }
        [StringLength(500)]
        public string GenericName { get; set; }
        [StringLength(500)]
        public string UnitStrength { get; set; }
        [StringLength(500)]
        public string PresenatationType { get; set; }
        public decimal? Quantity { get; set; }
        [ForeignKey("PharmacyrequsitionId")]
       public virtual PharmacyRequisition PharmacyRequisitions { get; set; }


    }
}
