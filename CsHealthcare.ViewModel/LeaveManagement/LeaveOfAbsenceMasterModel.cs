using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.LeaveManagement
{
    public partial class LeaveOfAbsenceMasterModel
    {
       [Display(Name="Id")]
        public string Id { get; set; }
        [Display(Name = "Leave Reason")]
        public string LeaveReason { get; set; }
        [Display(Name = "EmployeeInfo Id")]
        public string EmployeeInfoId { get; set; }
        [Display(Name = "EmployeeInfo First Name")]
        public string EmployeeInfoFirstName { get; set; }
        [Display(Name = "Requested Date")]
        public DateTime? RequestedDate { get; set; }
        [Display(Name = "Note")]
        public string Note { get; set; }
        [Display(Name = "Covering User Id")]
        public string CoveringUserId { get; set; }
        [Display(Name = "Varify User Id")]
        public string VarifyUserId { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "RecStatus")]
        public string RecStatus { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
    }
}
