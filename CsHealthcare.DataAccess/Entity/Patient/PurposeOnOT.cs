using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Cabin;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class PurposeOnOT
    {
        [Key]
        public int Id { get; set; }
        public int PurposeId { get; set; }
        public int OperationTheatreId { get; set; }
        public decimal PurposeAmount { get; set; }
      
        public decimal Quantity { get; set; }
        public decimal SubTotal { get; set; }
        [ForeignKey("PurposeId")]
        public virtual Purpose Purpose { get; set; }
        [ForeignKey("OperationTheatreId")]
        public virtual OperationTheatre OperationTheatre { get; set; }
    }
}
