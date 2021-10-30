using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugSaleDetails
    {
        public int Id { get; set; }
        public int? DrugId { get; set; }
        public int? DrugSaleId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? SaleDiscount { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("DrugSaleId")]
        public virtual DrugSale DrugSale { get; set; }
        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }
    }
}
