using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
    public partial class CabinRent:AuditableEntity
    {
        [Key]
    
        public int Id { get; set; }
        [Required]
        
        public int CabinId { get; set; }
        [Required]
        public string AdmissionNo { get; set; }
        public int PatientId { get; set; }
        public string PatientCode { get; set; }
        [Required]
        [StringLength(50)]
        public string MobileNo { get; set; }
        [Required]
        public string EmergencyContactPerson { get; set; }
     
        public DateTime RentDate { get; set; }

        public DateTime? DischargeDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
        public decimal Rate { get; set; }
      
        
        public int? Duration { get; set; }
        public decimal TotalPrice { get; set; }

    
     
        [ForeignKey("CabinId")]
        public virtual Cabin Cabin { get; set; }
        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }

    }
}
