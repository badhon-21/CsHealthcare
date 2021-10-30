using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Physiotherapy
{
    public class OpdTherapyDetails
    {
        [Key]
        public int Id { get; set; }
        public int OPDTherapyId { get; set; }
        public decimal TherapyPrice { get; set; }
        public decimal SubTotal { get; set; }
        public int? Quantity{ get; set; }
        public decimal? Discount { get; set; }
        public int PhysiotherapyId { get; set; }
        [ForeignKey("OPDTherapyId")]
        public virtual OPDTherapy OpdTherapy { get; set; }
        [ForeignKey("PhysiotherapyId")]
        public virtual Physiotherapy Physiotherapy { get; set; }
    }
}
