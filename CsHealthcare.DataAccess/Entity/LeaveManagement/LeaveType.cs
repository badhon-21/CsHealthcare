using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.LeaveManagement
{
    public partial class LeaveType
    {
        public LeaveType()
        {
            LeavePlanRates = new HashSet<LeavePlanRate>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string TypeName { get; set; }
        [StringLength(50)]
        public string  Abbreviation{ get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        [StringLength(1)]
        public string HolidayConcurrent { get; set; }
        [StringLength(1)]
        public string Bank { get; set; }
        [StringLength(1)]
        public string IsPaid { get; set; }
        [StringLength(1)]
        public string IsAdvance { get; set; }
        [StringLength(1)]
        public string RecStatus { get; set; }
        [StringLength(50)]
        public string SetupUser { get; set; }
        public DateTime SetupDate { get; set; }
        public virtual ICollection<LeavePlanRate> LeavePlanRates { get; set; }
    }
}
