using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
   public class PatientHistoryModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }

        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Display(Name = "History Taken Date")]
        public DateTime HistoryTakenDate { get; set; }

        [Display(Name = "History Taken Time")]
        public DateTime HistoryTakenTime { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }



        [Display(Name = "Patient Allergy Information")]
        public virtual List<PatientAllergyInformationModel> PatientAllergyInformation { get; set; }

        [Display(Name = "Patient Chief Complaint")]
        public virtual List<PatientChiefComplaintModel> PatientChiefComplaint { get; set; }

        [Display(Name = "Patient Family Disease")]
        public virtual List<PatientFamilyDiseaseModel> PatientFamilyDisease { get; set; }

        [Display(Name = "Patient General Exam")]
        public virtual List<PatientGeneralExamModel> PatientGeneralExam { get; set; }


        [Display(Name = "Patient Past History Of Madication")]
        public virtual List<PatientPastHistoryOfMadicationModel> PatientPastHistoryOfMadication { get; set; }

        [Display(Name = "Patient Past Illness")]
        public virtual List<PatientPastIllnessModel> PatientPastIllness { get; set; }

        [Display(Name = "Patient Personal History")]
        public virtual List<PatientPersonalHistoryModel> PatientPersonalHistory { get; set; }

        [Display(Name = "Patient Prescription")]
        public virtual List<PatientPrescriptionModel> PatientPrescription { get; set; }
    }

    public class PatientHistorySummaryModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        public int SerialNo { get; set; }

        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Display(Name = "Dorcor Id")]
        public string DorcorId { get; set; }

        [Display(Name = "Dorcor Name")]
        public string DorcorName { get; set; }

        [Display(Name = "History Taken Date")]
        public DateTime HistoryTakenDate { get; set; }

        [Display(Name = "History Taken Time")]
        public DateTime HistoryTakenTime { get; set; }

        [Display(Name = "Record Status")]
        public string RecordStatus { get; set; }

        [Display(Name = "Setup User")]
        public string SetupUser { get; set; }

        [Display(Name = "Setup Date Time")]
        public DateTime? SetupDateTime { get; set; }

    }

    public class PatientHistoryMiniModel
    {

        public int Id { get; set; }

        public DateTime HistoryTakenDate { get; set; }

    }
}
