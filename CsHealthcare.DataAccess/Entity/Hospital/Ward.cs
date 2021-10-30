using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Hospital
{
   public partial class Ward
    {
       public Ward() 
       {
            Beds = new HashSet<Bed>();
        }
        [Key]
        public int Id { get; set; }

      
        //public int WardTypeId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public decimal PriceByDay { get; set; }
        //[ForeignKey("WardTypeId")]
        //public virtual WardType WardType { get; set; }
        public virtual ICollection<Bed> Beds { get; set; }
    }
}
