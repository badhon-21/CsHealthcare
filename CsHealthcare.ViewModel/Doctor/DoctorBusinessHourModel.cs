using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Doctor
{
   public class DoctorBusinessHourModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }

        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Display(Name = "Week Day")]
        public string WeekDay { get; set; }

        [Display(Name = "From Time")]
        public DateTime FromTime { get; set; }

        [Display(Name = "To Time")]
        public DateTime ToTime { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

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
