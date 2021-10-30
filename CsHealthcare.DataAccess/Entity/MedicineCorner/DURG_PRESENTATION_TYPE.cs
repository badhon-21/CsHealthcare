using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using NumberNinty.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public partial class DURG_PRESENTATION_TYPE :AuditableEntity
    {

        public DURG_PRESENTATION_TYPE()
        {
            DRUGS = new HashSet<DRUG>();
           
        }
        [Key]
        public int DPT_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string DPT_DESCRIPTION { get; set; }

     
     
        public virtual ICollection<DRUG> DRUGS { get; set; }

        
    }
}
