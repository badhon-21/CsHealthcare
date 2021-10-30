using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Canteen
{
   public class CanteenFoodInPatientDetails
    {
        [Required]
        public string Id { get; set; }
       
        public int CanteenFoodInPatientId { get; set; }

     
        public string ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal CostPrice { get; set; }
        
        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }
        
        public decimal Total { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("CanteenFoodInPatientId")]
        public virtual CanteenFoodInPatient CanteenFoodInPatient { get; set; }

    }
}
