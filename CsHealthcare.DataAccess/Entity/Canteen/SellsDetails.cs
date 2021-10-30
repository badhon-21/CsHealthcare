using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Canteen
{
  public partial  class SellsDetails
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string SellsId { get; set; }

        [Required]
        public string ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal CostPrice { get; set; }

        public decimal TotalCostPrice { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }

        public decimal? Discount { get; set; }

        public decimal Total { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("SellsId")]
        public virtual Sells Sells { get; set; }
    }
}
