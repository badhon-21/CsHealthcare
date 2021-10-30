using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.LeaveManagement
{
    public partial class LeavePlan
    {
        public LeavePlan()
        {
            LeavePlanRates = new HashSet<LeavePlanRate>();
        }
        [Key]
        public string Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(1)]
        public string IsYearSeniority { get; set; }
        [StringLength(1)]
        public string RecStatus { get; set; }
        [StringLength(50)]
        public string SetupUser { get; set; }
        public DateTime SetupDate { get; set; }

        public virtual ICollection<LeavePlanRate> LeavePlanRates { get; set; }
    }
}
