using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
   public class ShiftInfoModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Sift Title")]
        public string Title { get; set; }
        [Display(Name = "Sift Type")]
        public string Type { get; set; }
        [Display(Name = "Start Day")]
        public string StartDay { get; set; }
        [Display(Name = "Day On")]
        public int? DayOn { get; set; }
        [Display(Name = "Day Off")]
        public int? DayOff { get; set; }
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Display(Name = "Working Hour")]
        public string WorkingHour { get; set; }
        [Display(Name = "End Time")]
        public string EndTime { get; set; }
        [Display(Name = "Has Lunch/Dinner?")]
        public bool HasLunchDinner { get; set; }

        [Display(Name = "Begin Time")]
        public string BeginTime { get; set; }
        [Display(Name = "Duration")]
        public string Duration { get; set; }

        [Display(Name = "RecStatus")]
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
