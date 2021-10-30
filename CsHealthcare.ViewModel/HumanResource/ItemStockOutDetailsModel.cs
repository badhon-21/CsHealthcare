using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
   public class ItemStockOutDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Store Item Id")]
        public int? StoreItemId { get; set; }
        [Display(Name = "Store Item Name")]
        public string StoreItemName{ get; set; }
        [Display(Name = "Item StockOut Id")]
        public int? ItemStockOutId { get; set; }
        
       
        [Display(Name = "Quantity ")]
        public decimal? Quantity { get; set; }


      
    }
}
