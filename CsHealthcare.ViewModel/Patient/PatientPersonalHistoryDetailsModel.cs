using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientPersonalHistoryDetailsModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Personal History Id")]
        public int PatientPersonalHistoryId { get; set; }

        [Display(Name = "Patient Personal Attribute Id")]
        public int PatientPersonalAttributeId { get; set; }

        [Display(Name = "Patient Personal Attribute Title")]
        public string PatientPersonalAttributeTitle { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
