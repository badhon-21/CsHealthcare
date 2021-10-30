using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{

    [Table("VW_DRUG_SALE_ALL")]
    public class VW_DRUG_SALE_ALL
    {
        [Key]
        public Guid VID { get; set; }
        public String Ctype { get; set; }
        public string MemoNo { get; set; }
     
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
