using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class ChiefComplaint : AuditableEntity
    {
        public ChiefComplaint()
        {
            PatientChiefComplaints = new HashSet<PatientChiefComplaint>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public virtual ICollection<PatientChiefComplaint> PatientChiefComplaints { get; set; }
    }
}