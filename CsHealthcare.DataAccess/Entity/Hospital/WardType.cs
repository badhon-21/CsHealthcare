using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Hospital
{
  public partial  class WardType
    {
        //public WardType()
        //{
        //    Wards = new HashSet<Ward>();
        //}
        [Key]

        public int Id { get; set; }

   
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Status { get; set; }
        //public virtual ICollection<Ward> Wards { get; set; }

    }
}
