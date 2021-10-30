using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsHealthcare.DataAccess.ViewModel.Dialysis
{
    public class PatientEnrollDialysisModel 
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Serial No")]
        public int SerialNo { get; set; }

        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }

        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Time")]
        public string Time { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

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