using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Operation
{
    public class OperationNoteModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Prescription Id")]
        public int PrescriptionId { get; set; }

        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }
        [Display(Name = "Doctor Name ")]
        public string DoctorName { get; set; }
        [Display(Name = "Place Of Operation")]
        public string PlaceOfOperation { get; set; }
        [Display(Name = "Date Of Operation")]

        public DateTime DateOfOperation { get; set; }

        [Display(Name = "Pre Operation Diagnosis")]
        public string PreOpDiagnosis { get; set; }
        [Display(Name = "Per Operation Diagnosis")]
     
        public string PerOpDiagnosis { get; set; }

        [Display(Name = "Name of Operation ")]
        public string NameOfOperation { get; set; }

        [Display(Name = "Anaesthesia")]
        public string Anaesthesia { get; set; }

        [Display(Name = "Anesthesiologist")]
        public string Anesthesiologist { get; set; }

        [Display(Name = "Time Of Surgery")]
        public string TimeOfSurgery { get; set; }

        [Display(Name = "Time Of Anesthesia ")]
        public string TimeOfAnesthesia { get; set; }

        [Display(Name = "Surgeon ")]
        public string Surgeon { get; set; }

        [Display(Name = "Asistant ")]
        public string Asistant { get; set; }

        [Display(Name = "Position Of Patient ")]
        public string PositionOfPatient { get; set; }
        [Display(Name = "Description ")]
        public string Description { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
