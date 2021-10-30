using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class InPatientTest :AuditableEntity
    {
        public InPatientTest()
        {

            InPatientTestDetails = new HashSet<InPatientTestdetails>();

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string PatientCode { get; set; }
        public int PatientId { get; set; }


        
        public decimal? DeuAmount { get; set; }
        [StringLength(100)]
        public string VoucherNo { get; set; }
        public int? ItemQuantity { get; set; }
        public DateTime TestDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AdmissionNo { get; set; }
        public string Remark { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        public virtual ICollection<InPatientTestdetails> InPatientTestDetails { get; set; }
    }
}
