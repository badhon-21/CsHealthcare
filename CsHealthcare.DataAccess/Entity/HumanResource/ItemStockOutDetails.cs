using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Store;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public class ItemStockOutDetails
    {

        public int Id { get; set; }
      
        public int? ItemStockOutId { get; set; }
        public int? StoreItemId { get; set; }

        public string StoreItemName { get; set; }
        public decimal? Quantity { get; set; }
      
       
        [ForeignKey("ItemStockOutId")]
        public virtual ItemStockOut ItemStockOut { get; set; }

    }
}
