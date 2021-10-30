using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Patient
{
    public class PatientOldInvestigationModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Display(Name = "Test Category Id")]
        public int TestCategoryId { get; set; }

        [Display(Name = "Test Category Name")]
        public string TestCategoryName { get; set; }

        [Display(Name = "Test Id")]
        public int TestId { get; set; }

        [Display(Name = "Test Name")]
        public string TestName { get; set; }

        [Display(Name = "Findings")]
        public string Findings { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
