using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Entity.Stock;

namespace CsHealthcare.DataAccess.Entity.Store
{
   public partial class StockInDetails
    {

        [Key]
        public int Id { get; set; }

        public int? StockInId { get; set; }

        public int? StoreItemId { get; set; }

     

        public decimal? CostPrice { get; set; }
        public decimal? UnitPrice { get; set; }

        public decimal? SubTotalPrice { get; set; }

        public decimal? SalePrice { get; set; }

        public int? StockQuantity { get; set; }

        public int? AvailableQuantity { get; set; }

        public int? DisturbedQuantity { get; set; }

        public int? RemainingQuantity { get; set; }

        public DateTime? MafDate { get; set; }

        public DateTime? ExpDate { get; set; }

        public virtual StoreItem StoreItems { get; set; }

        public virtual StockIn StockIn { get; set; }
    }
}
