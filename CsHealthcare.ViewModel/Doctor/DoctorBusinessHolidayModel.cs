using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Doctor
{
   public class DoctorBusinessHolidayModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }

        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Specific Date")]
        public bool SpecificDate { get; set; }

        [Display(Name = "Day Of The Week")]
        public bool DayOfTheWeek { get; set; }

        [Display(Name = "Day Of The Month")]
        public bool DayOfTheMonth { get; set; }

        [Display(Name = "Day Of The Year")]
        public bool DayOfTheYear { get; set; }


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
