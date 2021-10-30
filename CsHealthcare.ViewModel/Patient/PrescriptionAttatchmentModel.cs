using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CsHealthcare.ViewModel.Patient
{
    public class PrescriptionAttatchmentModel
    {
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public string DoctorId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string FileName { get; set; }

        public HttpPostedFileBase MyFile { get; set; }
        //public string CroppedImagePath { get; set; }
        public string UploadedFilePath { get; set; }
    }
}
