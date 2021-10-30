using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientSpecialNoteModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Prescription Id")]
        public int PatientPrescriptionId { get; set; }

        [Display(Name = "Special Note Id")]
        public int SpecialNoteId { get; set; }

        [Display(Name = "Special Note")]
        public string SpecialNote { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
