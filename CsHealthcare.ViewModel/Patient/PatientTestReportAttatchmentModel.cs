using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientTestReportAttatchmentModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Test Date")]
        public DateTime TestDate { get; set; }
        [Display(Name = "Attatchment Date")]
        public DateTime AttatchmentDate { get; set; }
        [Display(Name = "Test Name")]
        public string TestName { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        public HttpPostedFileBase MyFile { get; set; }
        //public string CroppedImagePath { get; set; }
        public string UploadedFilePath { get; set; }
    }
}
