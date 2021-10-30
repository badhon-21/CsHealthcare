using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.DataAccess.Entity.Stock
{
    public partial class DrugStockDetails
    {
        [Key]
        public int Id { get; set; }

        public int? DrugStockInId { get; set; }

        public int? DRUGId { get; set; }

        public DateTime? MafDate { get; set; }

        public DateTime? ExpDate { get; set; }

        public decimal? CostPrice { get; set; }
        public decimal? UnitPrice { get; set; }

        public decimal? SubTotalPrice { get; set; }

        public decimal? SalePrice { get; set; }

        public int? StockQuantity { get; set; }

        public int? AvailableQuantity { get; set; }

        public int? DisturbedQuantity { get; set; }

        public int? RemainingQuantity { get; set; }

        public int? DiscountPercent { get; set; }

        public virtual DRUG DRUG { get; set; }

        public virtual DrugStockIn DrugStockIn { get; set; }
    }
}
