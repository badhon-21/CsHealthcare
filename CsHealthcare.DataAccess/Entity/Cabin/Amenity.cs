using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
    public partial class Amenity
    {
        public Amenity()
        {
            CabinAmenities = new HashSet<CabinAmenity>();
        }
        [Key]
      
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Url { get; set; }

        public virtual ICollection<CabinAmenity> CabinAmenities { get; set; }
    }
}
