using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using NumberNinty.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public partial class DRUG_MANUFACTURER: AuditableEntity
    {

        public DRUG_MANUFACTURER()
        {
           DRUGS = new HashSet<DRUG>();
       
        }
        [Key]
        public int DM_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DM_NAME { get; set; }

        [StringLength(20)]
        public string DM_TYPE { get; set; }

        [StringLength(50)]
        public string DM_CONTACT_PERSON { get; set; }

        [StringLength(500)]
        public string DM_ADDRESS { get; set; }

        [StringLength(50)]
        public string DM_MOBILE { get; set; }

        [StringLength(50)]
        public string DM_PHONE { get; set; }

        [StringLength(50)]
        public string DM_FAX { get; set; }

        [StringLength(50)]
        public string DM_EMAIL { get; set; }

        [StringLength(50)]
        public string DM_WEB { get; set; }

        [StringLength(1)]
        public string DM_STATUS { get; set; }

       
      
        public virtual ICollection<DRUG> DRUGS { get; set; }

     
      //  public virtual ICollection<DRUG_STOCK_IN> DRUG_STOCK_IN { get; set; }

    }
}
