using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{
    public class VW_Department_Wise_DRUG_STOCK
    {
        [Key]
        public Guid ID { get; set; }

        public int D_ID { get; set; }
        public string D_TRADE_NAME { get; set; }
        public string D_UNIT_STRENGTH { get; set; }
        public string DPT_DESCRIPTION { get; set; }
        public string drugName { get; set; }
        public string ComId { get; set; }
        public string ComName { get; set; }
        public string MemoNo { get; set; }
        public DateTime Date { get; set; }
        
        
        
        public decimal? CostPrice { get; set; }
        public decimal UnitPrice { get; set; }
        
        public int Quantity { get; set; }
       
        public int? RemainingQuantity { get; set; }
       
        public int stockDetailsId { get; set; }
        public int DrugDepartmentWiseStockInId { get; set; }
    }
}
