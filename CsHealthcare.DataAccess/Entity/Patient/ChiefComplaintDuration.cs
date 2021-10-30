using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class ChiefComplaintDuration : AuditableEntity
    {
        public ChiefComplaintDuration()
        {
            PatientChiefComplaints = new HashSet<PatientChiefComplaint>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Details { get; set; }

        public virtual ICollection<PatientChiefComplaint> PatientChiefComplaints { get; set; }
    }
}