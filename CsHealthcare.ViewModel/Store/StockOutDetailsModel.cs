using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Store
{
  public  class StockOutDetailsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Store Item Id")]
        public int? StoreItemId { get; set; }

        [Display(Name = "Store Item Name")]
        public string StoreItemName { get; set; }
        [Display(Name = "StockOut Item Id")]
        public int? StockOutItemId { get; set; }
        [Display(Name = "UnitPrice")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Added Quantity")]
        public int AddedQuantity { get; set; }
        [Display(Name = "SubTotal")]
        public decimal? SubTotal { get; set; }
        [Display(Name = "Total")]
        public decimal? Total { get; set; }
    }
}
