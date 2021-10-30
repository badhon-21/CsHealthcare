using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class PatientTestReportAttatchment
    {
        [Key]
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public int PatientId { get; set; }
        public DateTime TestDate { get; set; }
        public DateTime AttatchmentDate { get; set; }
        public string TestName { get; set; }
        public string FileName { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
    }
}
