using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Patient;

namespace CsHealthcare.DataAccess.Entities.Operation
{
    public class OperationNote : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int PrescriptionId { get; set; }

        [StringLength(50)]
        public string DoctorId { get; set; }

        [StringLength(100)]
        public string PlaceOfOperation { get; set; }

        [Required]
        public DateTime DateOfOperation { get; set; }

        [StringLength(150)]
        public string PreOpDiagnosis { get; set; }

        [StringLength(150)]
        public string PerOpDiagnosis { get; set; }

        [StringLength(100)]
        public string NameOfOperation { get; set; }

        [StringLength(50)]
        public string Anaesthesia { get; set; }

        [StringLength(100)]
        public string Anesthesiologist { get; set; }

        [StringLength(50)]
        public string TimeOfSurgery { get; set; }

        [StringLength(50)]
        public string TimeOfAnesthesia { get; set; }

        [StringLength(100)]
        public string Surgeon { get; set; }

        [StringLength(100)]
        public string Asistant { get; set; }

        [StringLength(100)]
        public string PositionOfPatient { get; set; }

        public string Description { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }

        [ForeignKey("PrescriptionId")]
        public virtual PatientPrescription PatientPrescription { get; set; }
    }
}