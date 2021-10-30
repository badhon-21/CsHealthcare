using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientPrescriptionModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient History Id")]
        public int PatientHistoryId { get; set; }

        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }

        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Time")]
        public DateTime Time { get; set; }

        [Display(Name = "Brief Summary")]
        public string BriefSummary { get; set; }
        [Display(Name = "Orthopedic Findings")]
        public string OrthopedicFindings { get; set; }
        [Display(Name = "Diagonosis")]
        public string Diagonosis { get; set; }
        [Display(Name = "Next Review Date")]
        public string NextReviewDate { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Patient Investigation")]
        public virtual List<PatientInvestigationModel> PatientInvestigation { get; set; }

        [Display(Name = "Patient Special Note")]
        public virtual List<PatientSpecialNoteModel> PatientSpecialNote { get; set; }

        [Display(Name = "Patient Treatment")]
        public virtual List<PatientTreatmentModel> PatientTreatment { get; set; }


    }

    public class PrescriptionSummary
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public string DoctorId { get; set; }

        public DateTime PrescriptionDate { get; set; }
    }

}
