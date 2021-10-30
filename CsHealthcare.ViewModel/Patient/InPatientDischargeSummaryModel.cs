using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Patient
{
    public class InPatientDischargeSummaryModel:AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        public string AdmissionNo { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Admission Date")]
        public DateTime AdmissionDate { get; set; }
        [Display(Name = "Discharge Date")]
        public DateTime DischargeDate { get; set; }
        [Display(Name = "Attending Physician")]
        public string AttendingPhysician { get; set; }
        [Display(Name = "Reffering Physician")]
        public string RefferingPhysician { get; set; }
        [Display(Name = "Consulting Physician")]
        public string ConsultingPhysician { get; set; }
        [Display(Name = "Condition On Discharge")]
        public string ConditionOnDischarge { get; set; }
        [Display(Name = "Discharge By")]
        public string DischargeBy { get; set; }
      
        [Display(Name = "Final Diadiagnosis")]
       
        public string FinalDiadiagnosis { get; set; }
        [Display(Name = "Operation Date")]
        public DateTime OperationDate { get; set; }
        [Display(Name = "Operation Time")]
        public string OperationTime { get; set; }
        [Display(Name = "Name Of Operation")]
        public string NameOfOperation { get; set; }
        [Display(Name = "Name Of Anesthesia")]
        public string NameOfAnesthesia { get; set; }
        [Display(Name = "Indication Of Operation")]
        public string IndicationOfOperation { get; set; }
        [Display(Name = "Clinical Findings")]
        public string ClinicalFindings { get; set; }
        [Display(Name = "Baby Note")]
        public string BabyNote { get; set; }
        [Display(Name = "Treatment During Hospital")]
        public string TreatmentDuringHospital { get; set; }
        [Display(Name = "Instruction")]
        public string Instruction { get; set; }
        [Display(Name = "Consultation Dictician")]
        public string ConsultationDictician { get; set; }
        [Display(Name = "Consultineuning Rx")]
        public string ConsultineuningRx { get; set; }
        [Display(Name = "Follow Up")]
        public string FollowUp { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        public string InvestigationDuringAdmission { get; set; }
    }
}
