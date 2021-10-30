using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Cabin;

namespace CsHealthcare.DataAccess.Entity
{
    public class ICURent
    {
        [Key]

        public int Id { get; set; }
        

        public int ICUId { get; set; }
        

        public int ICUBedsId { get; set; }
        
        

        public DateTime RentDate { get; set; }

        
        public string Status { get; set; }
        public decimal Rate { get; set; }

        public string PatientCode { get; set; }
        
        public decimal TotalPrice { get; set; }

        [ForeignKey("ICUId")]
        public virtual ICU ICU { get; set; }
        [ForeignKey("ICUBedsId")]
        public virtual ICUBeds ICUBeds { get; set; }
    }
}
