using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public partial  class Holiday:AuditableEntity
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int NoDay { get; set; }
        public DateTime StartDaY { get; set; }
        public DateTime EndDaY { get; set; }
        [StringLength(100)]
        public string Notes { get; set; }
    }
}
