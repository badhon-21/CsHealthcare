using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.LeaveManagement
{
    public partial class LeaveOfAbsenceDetails 
    {
        [Key]
        public string Id { get; set; }

        public int LeaveTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LeaveOfAbsenceMasterId { get; set; }
        public int TotalHours { get; set; }
        [StringLength(50)]
        public string LeaveYear { get; set; }
        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType { get; set; }
        [ForeignKey("LeaveOfAbsenceMasterId")]
        public virtual LeaveOfAbsenceMaster LeaveOfAbsenceMaster { get; set; }
    }
}
