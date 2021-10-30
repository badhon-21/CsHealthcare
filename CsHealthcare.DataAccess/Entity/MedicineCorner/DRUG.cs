using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using NumberNinty.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    [Table("DRUG")]
    public partial class DRUG :AuditableEntity
    {
        
        public DRUG()
        {
            DrugsSelectedGroupses = new HashSet<DrugsSelectedGroups>();
            DrugDoseCharts = new HashSet<DrugDoseChart>();
        }

        [Key]
        public int D_ID { get; set; }

        public int D_DM_ID { get; set; }

        public int D_DPT_ID { get; set; }

        [Required]
        [StringLength(500)]
        public string D_TRADE_NAME { get; set; }

        [StringLength(500)]
        public string D_GENERIC_NAME { get; set; }

        [StringLength(500)]
        public string D_UNIT_STRENGTH { get; set; }

        [StringLength(500)]
        public string D_DISPENSE_FROM { get; set; }

        public int? D_REORDER_LEVEL { get; set; }

       
        public int? D_DISCOUNT { get; set; }

        public int? D_PACK_QTY { get; set; }

        [StringLength(1)]
        public string D_STATUS { get; set; }

        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? SalePrice { get; set; }
        public virtual DRUG_MANUFACTURER DRUG_MANUFACTURER { get; set; }

        public virtual DURG_PRESENTATION_TYPE DURG_PRESENTATION_TYPE { get; set; }

        public virtual ICollection<DrugsSelectedGroups> DrugsSelectedGroupses { get; set; }

        public virtual ICollection<DrugDoseChart> DrugDoseCharts { get; set; }

    }
}
