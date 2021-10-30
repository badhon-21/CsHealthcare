using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{

    [Table("VW_IPD_DRUG_SALE_TOTAL")]
    public class VW_IPD_DRUG_SALE_TOTAL
    {
        [Key]
        public Guid VID { get; set; }
      
        public string AdmissionNo { get; set; }
   
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        
        public decimal DrugSale { get; set; }

        public decimal DrugReturn { get; set; }

        public decimal TotalSale { get; set; }

    }
}
