using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
   public partial  class CabinType:AuditableEntity
    {
        public CabinType()
        {
            Cabins = new HashSet<Cabin>();
        }
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Status { get; set; }


        public virtual ICollection<Cabin> Cabins { get; set; }
    }
}
