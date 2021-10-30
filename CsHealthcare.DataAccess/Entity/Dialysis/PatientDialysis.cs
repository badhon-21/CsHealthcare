using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Dialysis
{
    public class PatientDialysis : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string MachinNumber { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantContactNumber { get; set; }
        public int? NoOfTakenDialysis { get; set; }
        public string LastDialysisTakenHospital{ get; set; }
        public DateTime? LastDialysisTakenDate { get; set; }
        public decimal? Hemoglobin { get; set; }
        public decimal? LastWeight { get; set; }

        public string PreDialysisBodyWeight { get; set; }
        public string PreDialysisBodyBP { get; set; }
        public string PreDialysisBodyPulse { get; set; }
        public string PreDialysisBodyResp { get; set; }
        public string PreDialysisBodyTemp { get; set; }

        public string PostDialysisBodyWeight { get; set; }
        public string PostDialysisBodyBP { get; set; }
        public string PostDialysisBodyPulse { get; set; }
        public string PostDialysisBodyResp { get; set; }
        public string PostDialysisBodyTemp { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }
    }
}