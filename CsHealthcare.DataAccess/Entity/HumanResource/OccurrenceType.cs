using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public partial class OccurrenceType:AuditableEntity
    {
        public OccurrenceType()
        {
            Occurrences = new HashSet<Occurrence>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
         public string Name { get; set; }
        [StringLength(100)]
        public string Note { get; set; }

        [StringLength(50)]
        public string Abbreviation { get; set; }
        [StringLength(1)]
        public string Status { get; set; }

        public virtual  ICollection<Occurrence> Occurrences { get; set; } 

    }
}
