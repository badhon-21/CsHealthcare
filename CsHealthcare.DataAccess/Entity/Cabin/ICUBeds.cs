using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
    public class ICUBeds
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceByDay { get; set; }
        public decimal PriceByHour { get; set; }
        public int IcuId { get; set; }
        [ForeignKey("IcuId")]
        public virtual ICU Icu { get; set; }
    }
}
