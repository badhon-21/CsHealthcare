using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientFamilyDiseaseModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient History Id")]
        public int PatientHistoryId { get; set; }

        [Display(Name = " Disease ID")]
        public int DiseaseId { get; set; }

        [Display(Name = "Disease Name")]
        public string DiseaseName { get; set; }

        [Display(Name = "Family Tree Id")]
        public int FamilyTreeId { get; set; }

        [Display(Name = "Ms Family Tree Title")]
        public string FamilyTreeTitle { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
