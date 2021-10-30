using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.LeaveManagement
{
   public class LeavePlanRateModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "LeaveType Id")]
        public int LeaveTypeId { get; set; }
        [Display(Name = "Type Name")]
        public string TypeName { get; set; }
        [Display(Name = "LeavePlan Id")]
        public string LeavePlanId { get; set; }
        [Display(Name = "LeavePlan Name")]
        public string LeavePlanName { get; set; }

        
        [Display(Name = "Start Month")]
        public int StartMonth { get; set; }
        [Display(Name = "End Month")]
        public int EndMonth { get; set; }
        [Display(Name = "Time Days")]
        public int TimeDays { get; set; }
        
    }
}
