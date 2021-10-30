using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Diagnostic;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientOldInvestigation : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public string Findings { get; set; }

        [ForeignKey("TestId")]
        public virtual Test_Name Test { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }
    }
}