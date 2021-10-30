using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
    public class ICU
    {
        public ICU()
        {

            ICUBeds = new HashSet<ICUBeds>();

        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public decimal PriceByDay { get; set; }
        //public decimal PriceByHour { get; set; }
        public virtual ICollection<ICUBeds> ICUBeds { get; set; }
    }
}
