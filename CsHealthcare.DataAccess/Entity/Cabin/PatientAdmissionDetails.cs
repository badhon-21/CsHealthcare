using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Cabin
{
    public partial class PatientAdmissionDetails
    {
        [Key]
        public int Id { get; set; }
        public int PatientAdmissionId { get; set; }
        public int PurposeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("PatientAdmissionId")]
        public virtual PatientAdmission PatientAdmission { get; set; }
        [ForeignKey("PurposeId")]
        public virtual Purpose Purpose { get; set; }
    }
}
