using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.DataAccess.Entity.Store
{
   public class StockOutDetails
    {
        public int Id { get; set; }
        public int? StoreItemId { get; set; }
        public int? StockOutItemId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? SubTotal { get; set; }
       
        public decimal? Total { get; set; }
        [ForeignKey("StoreItemId")]
        public virtual StoreItem StoreItem { get; set; }
        [ForeignKey("StockOutItemId")]
        public virtual StockOutItem StockOutItem { get; set; }
    }
}
