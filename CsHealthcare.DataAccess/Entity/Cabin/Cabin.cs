using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
   public class Cabin:AuditableEntity
    {
        public Cabin()
        {
            CabinAmenities = new HashSet<CabinAmenity>();
            CabinRents = new HashSet<CabinRent>();
            
        }
        [Key]
     
        public int Id { get; set; }
        [Required]
     
        public int CabinTypeId { get; set; }
        //[Required]
        //[StringLength(50)]
        //public string AmenityId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        public decimal PriceByDay { get; set; }
        public virtual CabinType CabinType { get; set; }
        public virtual ICollection<CabinAmenity> CabinAmenities { get; set; }

        public virtual ICollection<CabinRent> CabinRents { get; set; }
    }
}
