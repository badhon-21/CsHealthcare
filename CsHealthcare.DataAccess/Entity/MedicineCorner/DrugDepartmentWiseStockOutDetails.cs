using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Stock;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
  public partial  class DrugDepartmentWiseStockOutDetails
    {

        [Key]
        public int Id { get; set; }

        public int? DrugDepartmentWiseStockOutId { get; set; }

        public int? DRUGId { get; set; }

       
        public decimal? UnitPrice { get; set; }

        public decimal SubTotalPrice { get; set; }

        public decimal? SalePrice { get; set; }

        public int? Quantity { get; set; }

        [ForeignKey("DRUGId")]
        public virtual DRUG DRUG { get; set; }
        [ForeignKey("DrugDepartmentWiseStockOutId")]

        public virtual DrugDepartmentWiseStockOut DrugDepartmentWiseStockOut { get; set; }
    }
}
