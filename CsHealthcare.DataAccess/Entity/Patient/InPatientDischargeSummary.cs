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
    public class InPatientDischargeSummary
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string PatientCode { get; set; }
        public string PatientName { get; set; }

       public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public string AttendingPhysician { get; set; }
        public string RefferingPhysician { get; set; }
        public string ConsultingPhysician { get; set; }
        public string ConditionOnDischarge { get; set; }
        public string DischargeBy { get; set; }
       
        public string FinalDiadiagnosis { get; set; }
        public DateTime OperationDate { get; set; }
        public string OperationTime { get; set; }
        public string NameOfOperation { get; set; }
        public string NameOfAnesthesia { get; set; }
        public string IndicationOfOperation { get; set; }
        public string ClinicalFindings { get; set; }
        public string BabyNote { get; set; }
        public string TreatmentDuringHospital { get; set; }
        public string Instruction { get; set; }
        public string ConsultationDictician { get; set; }
        public string ConsultineuningRx { get; set; }

        public string FollowUp { get; set; }
        public DateTime CreatedDate { get; set; }

        public string InvestigationDuringAdmission { get; set; }
    }
}

