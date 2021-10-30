using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{
    public class VW_Department1_Wise_DRUG_STOCK
    {
        [Key]
        public Guid ID { get; set; }

        public int D_ID { get; set; }
        public string D_TRADE_NAME { get; set; }
        public string D_UNIT_STRENGTH { get; set; }
        public string DPT_DESCRIPTION { get; set; }
        public string drugName { get; set; }
        
        public int StockQuantity { get; set; }
        public int SaleQuantity { get; set; }
        public int BufferStock { get; set; }
        public int HospitalSale { get; set; }
    }
}
