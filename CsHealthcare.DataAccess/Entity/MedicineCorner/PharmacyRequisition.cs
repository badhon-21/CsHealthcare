using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
   public partial class PharmacyRequisition
    {
       public PharmacyRequisition ()
       {
            PharmacyRequisitionDetails=new HashSet<PharmacyRequisitionDetails>();

    }

        public string Id { get; set; }
        [StringLength(100)]
        public string Department { get; set; }
        [StringLength(100)]
        public string RequisitionBy { get; set; }


        [StringLength(100)]
        public string RequisitionNo { get; set; }
    
        public DateTime RequisitionDate { get; set; }


        [StringLength(100)]
        public string ApprovedBy { get; set; }
       public virtual ICollection<PharmacyRequisitionDetails> PharmacyRequisitionDetails { get; set; }


    }
}
