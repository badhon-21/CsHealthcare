using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Hospital
{
  public partial  class Bed
    {
        [Key]
        public int Id { get; set; }
        public int WardId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string BedType { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("WardId")]
        public virtual Ward Ward { get; set; }
    }
}
