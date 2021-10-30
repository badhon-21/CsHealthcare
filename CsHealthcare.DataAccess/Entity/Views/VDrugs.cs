using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{
   
    [Table("V_Drugs")]
    public class VDrugs
    {
     [Key]
      public  Guid ID { get; set; }
        public int DrugID { get; set; }
        public string GenName { get; set; }
        public string TradeName { get; set; }
        public string Presentation { get; set; }
        public string UnitStrength { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string DispenseForm { get; set; }
        public int ReorderLevel { get; set; }
        public int pack_qty { get; set; }
        public string Status { get; set; }
        public string RecStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
