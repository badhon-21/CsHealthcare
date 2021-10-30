using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.DataAccess.Entity.LeaveManagement
{
    public partial class LeaveOfAbsenceMaster: AuditableEntity
    {
        [Key]
        public string Id { get; set; }
        [StringLength(50)]
        public string LeaveReason { get; set; }
        public string EmployeeInfoId { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string Note { get; set; }
        public string CoveringUserId { get; set; }
        public string VarifyUserId { get; set; }
        [StringLength(1)]
        public string Status { get; set; }

        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }

    }
}
