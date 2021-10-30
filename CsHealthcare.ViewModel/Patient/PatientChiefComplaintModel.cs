using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
   public class PatientChiefComplaintModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient History Id")]
        public int PatientHistoryId { get; set; }

        [Display(Name = "Chief Complaint Id")]
        public int ChiefComplaintId { get; set; }

        [Display(Name = "Chief Complaint")]
        public string ChiefComplaint { get; set; }

        [Display(Name = "Chief Complaint Duration Id")]
        public int ChifComplaintDurationId { get; set; }

        [Display(Name = "Chief Complaint Duration")]
        public string ChifComplaintDuration { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
