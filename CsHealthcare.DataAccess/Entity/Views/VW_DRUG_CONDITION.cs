using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{

    [Table("VW_DRUG_CONDITION")]
    public class VW_DRUG_CONDITION
    {
        [Key]
        public Guid VID { get; set; }
        public string CompanyName { get; set; }
        public string drugName { get; set; }
        public int box_size { get; set; }
      
        public int ReorderLevel { get; set; }
      
        public decimal MRP { get; set; }
        public decimal totalSaleQty { get; set; }
        public decimal totalSaleAmount { get; set; }
        public int totalStockQty { get; set; }
        public int totalreminingQty { get; set; }
      

    }
}
