using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{

    [Table("VW_DRUG_AVILABLE_STOCK")]
    public class VW_DRUG_AVILABLE_STOCK
    {
        [Key]
        public Guid ID { get; set; }
        public int DrugID { get; set; }
        public string drugName { get; set; }
        public string D_TRADE_NAME { get; set; }
        public string D_UNIT_STRENGTH { get; set; }
        public string DPT_DESCRIPTION { get; set; }


        public decimal COST_PRICE { get; set; }
        public int QTY { get; set; }
        public decimal PRICE { get; set; }

        public int DISCOUNT { get; set; }
    }
}
