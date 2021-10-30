using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class Anesthesia
    {
        public int Id { get; set; }
        public string AnesdthesiaName { get; set; }
        public decimal AnesthesiaPrice { get; set; }
        public int OperationTheatreId { get; set; }
        [ForeignKey("OperationTheatreId")]
        public virtual OperationTheatre OperationTheatre { get; set; }
    }
}
