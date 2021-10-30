using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsHealthcare.DataAccess.ViewModel.Dialysis
{
    public class PatientDialysisModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Id")]
        public int? PatientId { get; set; }

        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Display(Name = "Patient Age")]
        public int PatientAge { get; set; }

        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Display(Name = "Machin Number")]
        public string MachinNumber { get; set; }

        [Display(Name = "Consultant Name")]
        public string ConsultantName { get; set; }

        [Display(Name = "Consultant Contact Number")]
        public string ConsultantContactNumber { get; set; }

        [Display(Name = "No Of Taken Dialysis")]
        public int? NoOfTakenDialysis { get; set; }

        [Display(Name = "Last Dialysis Taken Hospital")]
        public string LastDialysisTakenHospital{ get; set; }

        [Display(Name = "Last Dialysis Taken Hospital")]
        public DateTime? LastDialysisTakenDate { get; set; }

        [Display(Name = "Hemoglobin")]
        public decimal? Hemoglobin { get; set; }

        [Display(Name = "LastWeight")]
        public decimal? LastWeight { get; set; }

        [Display(Name = "Pre Dialysis Body Weight")]
        public string PreDialysisBodyWeight { get; set; }

        [Display(Name = "Pre Dialysis Body BP")]
        public string PreDialysisBodyBP { get; set; }

        [Display(Name = "Pre Dialysis Body Pulse")]
        public string PreDialysisBodyPulse { get; set; }

        [Display(Name = "Pre Dialysis Body Resp")]
        public string PreDialysisBodyResp { get; set; }

        [Display(Name = "Pre Dialysis Body Temp")]
        public string PreDialysisBodyTemp { get; set; }

        [Display(Name = "Post Dialysis Body Weight")]
        public string PostDialysisBodyWeight { get; set; }

        [Display(Name = "Post Dialysis Body BP")]
        public string PostDialysisBodyBP { get; set; }

        [Display(Name = "Post Dialysis Body Pulse")]
        public string PostDialysisBodyPulse { get; set; }

        [Display(Name = "Post Dialysis Body Resp")]
        public string PostDialysisBodyResp { get; set; }

        [Display(Name = "Post Dialysis Body Temp")]
        public string PostDialysisBodyTemp { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

    }
}