using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.LeaveManagement
{
    public partial class LeavePlanRate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int LeaveTypeId { get; set; }
        [Required]
        public string LeavePlanId { get; set; }
        public int StartMonth { get; set; }
        public int EndMonth { get; set; }
        public int TimeDays { get; set; }
        [ForeignKey("LeavePlanId")]
        public virtual LeavePlan LeavePlan { get; set; }
        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType { get; set; }
    }
}
