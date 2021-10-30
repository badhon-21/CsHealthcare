using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.LeaveManagement
{
    public class LeaveOfAbsenceDetailsModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "LeaveType Id")]
        public int LeaveTypeId { get; set; }
        [Display(Name = "LeaveType Name")]
        public string LeaveTypeName { get; set; }
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
        [Display(Name = "LeaveOfAbsenceMasterId")]
        public string LeaveOfAbsenceMasterId { get; set; }
        [Display(Name = "Total Hours")]
        public int TotalHours { get; set; }
        [Display(Name = "Leave Year")]
        public string LeaveYear { get; set; }

    }
}
