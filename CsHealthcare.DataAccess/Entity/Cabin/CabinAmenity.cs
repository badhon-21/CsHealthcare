using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
    public partial class CabinAmenity
    {
        [Key]

        public int Id { get; set; }



        [Required]

        public int AmenityId { get; set; }
      
        public int CabinId { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [ForeignKey("CabinId")]
        public virtual Cabin Cabin { get; set; }

        [ForeignKey("AmenityId")]
        public virtual Amenity Amenity { get; set; }
    }
}
