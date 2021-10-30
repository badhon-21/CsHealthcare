using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Diagnostic;

namespace CsHealthcare.DataAccess.Entities.Patient
{
    public class PatientInvestigation : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PatientPrescriptionId { get; set; }
        public int TestId { get; set; }
        public string Findings { get; set; }

        [ForeignKey("TestId")]
        public virtual Test_Name Test { get; set; }

        [ForeignKey("PatientPrescriptionId")]
        public virtual PatientPrescription PatientPrescription { get; set; }
    }
}