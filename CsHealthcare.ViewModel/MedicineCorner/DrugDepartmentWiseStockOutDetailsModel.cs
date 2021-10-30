using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class DrugDepartmentWiseStockOutDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Drug Department Wise StockOut Id")]
        public int? DrugDepartmentWiseStockOutId { get; set; }
        [Display(Name = "DRUG Id")]
        public int? DRUGId { get; set; }
        [Display(Name = "DRUG Name")]
        public string DrugName { get; set; }

        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "SubTotal Price")]
        public decimal SubTotalPrice { get; set; }
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }
    }
}
