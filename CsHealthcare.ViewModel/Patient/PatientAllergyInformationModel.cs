using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientAllergyInformationModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient History Id")]
        public int PatientHistoryId { get; set; }

        [Display(Name = "Allergy Id")]
        public int AllergyInformationId { get; set; }

        [Display(Name = "Allergy Name")]
        public string AllergyName { get; set; }

        [Display(Name = "Allergy Substance Id")]
        public int AllergySubstanceId { get; set; }

        [Display(Name = "Allergy Substance Name")]
        public string AllergySubstanceName { get; set; }

        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
