using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugDepartmentWiseStockInDetails
    {
        [Key]
        public int Id { get; set; }
        public int? DrugId { get; set; }
        public string DrugName { get; set; }
        public int? Quantity { get; set; }
       
        public decimal? UnitPrice { get; set; }

        public decimal? SubTotalPrice { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int? RemainingQuantity { get; set; }
        public int DrugDepartmentWiseStockInId { get; set; }
        [ForeignKey("DrugDepartmentWiseStockInId")]
        public virtual DrugDepartmentWiseStockIn DrugDepartmentWiseStockIn { get; set; }
    }
}
