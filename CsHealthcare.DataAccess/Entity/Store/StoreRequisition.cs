using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.HumanResource;

namespace CsHealthcare.DataAccess.Entity.Store
{
  public partial  class StoreRequisition
    {

        public StoreRequisition()
        {
            StoreRequisitionDetails = new HashSet<StoreRequisitionDetails>();

        }

        public string Id { get; set; }
      
        public string DepartmentId { get; set; }
        [StringLength(100)]
        public string RequisitionBy { get; set; }


        [StringLength(100)]
        public string RequisitionNo { get; set; }

        public DateTime RequisitionDate { get; set; }


        [StringLength(100)]
        public string ApprovedBy { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DEPARTMENT Department { get; set; }
        public virtual ICollection<StoreRequisitionDetails> StoreRequisitionDetails { get; set; }

    }
}
