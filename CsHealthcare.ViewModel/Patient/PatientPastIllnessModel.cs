using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientPastIllnessModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient History Id")]
        public int PatientHistoryId { get; set; }

        [Display(Name = "Disease Id")]
        public int DiseaseId { get; set; }

        [Display(Name = " Disease")]
        public string Disease { get; set; }

        [Display(Name = "Disease Condition Id")]
        public int DiseaseConditionId { get; set; }

        [Display(Name = "Disease Condition")]
        public string DiseaseCondition { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
