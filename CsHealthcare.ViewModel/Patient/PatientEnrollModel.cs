using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
   public class PatientEnrollModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Serial No")]
        public int SerialNo { get; set; }

        [Display(Name = "Patient Information Id")]
        public int PatientInformationId { get; set; }

        [Display(Name = "Patient Information Name")]
        public string PatientInformationName { get; set; }

        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }

        [Display(Name = "Doctor  Name")]
        public string DoctorName { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Time")]
        public string Time { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
