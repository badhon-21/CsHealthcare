using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class AssistantDoctor
    {
        [Key]
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public decimal SurgeonAmount { get; set; }
        public int OperationTheatreId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual DoctorInformation DoctorInformation { get; set; }
        [ForeignKey("OperationTheatreId")]
        public virtual OperationTheatre OperationTheatre { get; set; }
    }
}
