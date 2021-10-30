using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{

    public class VW_DRUG_STOCK
    {
        [Key]
        public Guid ID { get; set; }

        public int D_ID { get; set; }
        public string D_TRADE_NAME { get; set; }
        public string D_UNIT_STRENGTH { get; set; }
        public string DPT_DESCRIPTION { get; set; }
        public string drugName { get; set; }
        public int ComId { get; set; }
        public string ComName { get; set; }
        public string LotId { get; set; }
        public string InvNo { get; set; }
        public DateTime InvDate { get; set; }
        public DateTime RecordDate { get; set; }
        public string DpoId { get; set; }
        public int D_REORDER_LEVEL { get; set; }
        public DateTime MafDate { get; set; }
        public DateTime ExpDate { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? DSD_COST_TOTAL_PRICE { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public int? AvailableQuantity { get; set; }
        public int? DisturbedQuantity { get; set; }
        public int? RemainingQuantity { get; set; }
        public decimal? DiscountPercent { get; set; }
        public int stockDetailsId { get; set; }
        public int DrugStockInId { get; set; }


    }
}
