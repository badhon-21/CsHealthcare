using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.LeaveManagement
{
    public class LeavePlanModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Seniority")]
        public string IsYearSeniority { get; set; }
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Setup User")]
        public string SetupUser { get; set; }
        [Display(Name = "Setup Date")]
        public DateTime SetupDate { get; set; }
    }
}
