using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public partial class ShiftInfo:AuditableEntity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(20)]
        public string Type { get; set; }
        [StringLength(50)]
        public string StartDay { get; set; }
 
        public int? DayOn { get; set; }
        public int? DayOff { get; set; }
        [StringLength(50)]
        public string  StartTime { get; set; }
        [StringLength(50)]
        public string WorkingHour { get; set; }
        [StringLength(50)]
        public string EndTime { get; set; }
        public bool HasLunchDinner { get; set; }

        [StringLength(50)]
        public string BeginTime { get; set; }
        [StringLength(50)]
        public string Duration { get; set; }


        
    }
}
