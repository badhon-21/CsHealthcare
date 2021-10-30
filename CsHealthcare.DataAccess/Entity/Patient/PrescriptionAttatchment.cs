using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class PrescriptionAttatchment
    {
        [Key]
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public string DoctorId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string FileName { get; set; }

    }
}
