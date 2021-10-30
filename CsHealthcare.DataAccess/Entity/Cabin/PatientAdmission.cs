using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Packages;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
    public partial class PatientAdmission:AuditableEntity
    {
        //public PatientAdmission()
        //{

        //    PatientAdmissionDetails = new HashSet<PatientAdmissionDetails>();

        //}
        [Key]
        public int Id { get; set; }
        public int? PackageId { get; set; }
        public string PatientCode { get; set; }
        public int CabinId { get; set; }
        public decimal CabinAmount { get; set; }

        public DateTime CabinRentDate { get; set; }
        public int? NoOfDays { get; set; }

        public decimal GivenAmount { get; set; }
        public decimal DeuAmount { get; set; }
        public decimal AdmissionFee  { get; set; }
        public decimal TotalAmount { get; set; }
      
        public string VoucherNo { get; set; }

        public string AdmissionNo { get; set; }

        public string EmergencyContactName { get; set; }
        public string EmergencyContactPersonRelation { get; set; }
        public string EmergencyContactMobile { get; set; }
        public string EmergencyContactPersonAddress { get; set; }
        public string RrreferenceDoctor { get; set; }
        public string Telephone { get; set; }
        public string HomePhone { get; set; }

        public string Status { get; set; }
        
        [ForeignKey("CabinId")]
        public virtual Cabin Cabin { get; set; }
       
        //[ForeignKey("PatientId")]
        //public virtual Patient.Patient Patient { get; set; }
        //public virtual ICollection<PatientAdmissionDetails> PatientAdmissionDetails { get; set; }

    }
}
