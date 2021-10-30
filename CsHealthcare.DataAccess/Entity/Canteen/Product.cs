using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Canteen
{
  public partial  class Product
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
      
        public string Name { get; set; }
    
        public string ShortDescription { get; set; }
        
        public string FullDescription { get; set; }
        
        public string SupplierId { get; set; }
        public int StockQuantity { get; set; }
        public int MinStockQuantity { get; set; }

        public decimal Price { get; set; }

        public decimal ProductCost { get; set; }

        public decimal Vat { get; set; }

        public decimal? SpecialPrice { get; set; }
       
        public DateTime? SpecialPriceStartDateTimeUtc { get; set; }
        
        public DateTime? SpecialPriceEndDateTimeUtc { get; set; }

        public string PictureUrl { get; set; }

        public decimal Weight { get; set; }
        
        
        public decimal Length { get; set; }
  
        public decimal Width { get; set; }
       
        public decimal Height { get; set; }
        public bool Published { get; set; }
      
        public bool Deleted { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<SellsDetails> SellsDetails { get; set; }
       
    }
}
