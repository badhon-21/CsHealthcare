using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
   public class DrugModel
    {
        [Display(Name = "D Id")]
        public int D_ID { get; set; }
        [Display(Name = "DM Id")]

        public int D_DM_ID { get; set; }
        [Display(Name = "DM Name")]

        public string D_DM_Name { get; set; }

        [Display(Name = "DPT Id")]
        public int D_DPT_ID { get; set; }

        [Display(Name = "DPT Name")]
        public string D_DPT_Name { get; set; }

        [Display(Name = "Trade Name")]
        public string D_TRADE_NAME { get; set; }

        [Display(Name = "Generic Name")]
        public string D_GENERIC_NAME { get; set; }

        [Display(Name = "Unit Strength")]
        public string D_UNIT_STRENGTH { get; set; }

        [Display(Name = "Dispense From")]
        public string D_DISPENSE_FROM { get; set; }
        [Display(Name = "Reorder Level")]
        public int? D_REORDER_LEVEL { get; set; }

        [Display(Name = "Discount")]
        public int? D_DISCOUNT { get; set; }

        [Display(Name = "Pack Quantity")]
        public int? D_PACK_QTY { get; set; }
        [Display(Name = "Discount")]
        public decimal? Discount { get; set; }
        [Display(Name = "Tax")]
        public decimal? Tax { get; set; }

        [Display(Name = "Status")]
        public string D_STATUS { get; set; }
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }
    }

    public class DrugSummaryModel
    {
        public int Id { get; set; }

        public int DrugManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public int PresentationTypeId { get; set; }

        public string PresentationTypeName { get; set; }
        public string TradeName { get; set; }

        public string GenericName { get; set; }

        public string UnitStrength { get; set; }

        public int? ReorderLevel { get; set; }

        public int? PackQuantity { get; set; }

        public string Status { get; set; }
        public decimal? SubTotal { get; set; }
        public int Quantity { get; set; }
    }
}
