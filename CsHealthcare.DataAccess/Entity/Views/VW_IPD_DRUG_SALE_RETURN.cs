using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Views
{

    [Table("VW_IPD_DRUG_SALE_RETURN")]
    public class VW_IPD_DRUG_SALE_RETURN
    {
        [Key]
        public Guid VID { get; set; }
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public string AdmissionNo { get; set; }
        public int PatientId { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal ReturnPrice { get; set; }
       
        public DateTime ReturnDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
