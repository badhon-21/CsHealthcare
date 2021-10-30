using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.HumanResource;

namespace CsHealthcare.ViewModel.Master
{
  public  class EducationModel
    {
        [Display(Name= "Id")]
        public int Id { get; set; }
        [Display(Name = "EmployeeInfo Id")]
        public string EmployeeInfoId { get; set; }
        [Display(Name = "EmployeeInfo Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Degree Name")]
        public string DegreeName { get; set; }
        [Display(Name = "Institution")]
        public string Institution { get; set; }

        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Display(Name = "Year")]
        public string Year { get; set; }
        [Display(Name = "Course Duration")]
        public decimal CourseDuration { get; set; }
        [Display(Name = "Scale")]
        public int Scale { get; set; }
        [Display(Name = "Record Status")]
        public string RecStatus { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

     
    }
}

