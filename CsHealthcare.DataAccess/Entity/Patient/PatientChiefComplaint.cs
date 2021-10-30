using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientChiefComplaint : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientHistoryId { get; set; }
        public int ChiefComplaintId { get; set; }
        public int ChiefComplaintDetailsId { get; set; }

        [ForeignKey("ChiefComplaintId")]
        public virtual ChiefComplaint ChiefComplaint { get; set; }

        [ForeignKey("ChiefComplaintDetailsId")]
        public virtual ChiefComplaintDuration ChiefComplaintDuration { get; set; }
    }
}