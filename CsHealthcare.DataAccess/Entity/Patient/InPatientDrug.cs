using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public partial class InPatientDrug:AuditableEntity
    {
        public InPatientDrug()
        {

            InPatientDrugDetails = new HashSet<InPatientDrugDetails>();
        }
        [Key]
        public int Id { get; set; }

        

        public int? PatientId { get; set; }
        public string PatientCode { get; set; }
        public decimal? Quantity { get; set; }
        
        public decimal? SaleDiscount { get; set; }
        public decimal? Vat { get; set; }
        public decimal? SpecialDiscount { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? SaleDateTime { get; set; }
        public string VoucherNo { get; set; }
        public string AdmissionNo { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public virtual ICollection<InPatientDrugDetails> InPatientDrugDetails { get; set; }
    }
}
