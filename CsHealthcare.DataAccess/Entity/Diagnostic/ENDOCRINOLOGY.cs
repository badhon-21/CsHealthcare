using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
   public partial class ENDOCRINOLOGY
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }
        [StringLength(100)]
        public string PatientCode { get; set; }
        [StringLength(50)]
        public string ReferanceName { get; set; }
        public string SpecimenName { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string TSH { get; set; }
        public string FreeT3 { get; set; }
        public string FreeT4 { get; set; }
        public string FSH { get; set; }
        public string LH { get; set; }
        public string Prolactin { get; set; }
        public string STestosterone { get; set; }

        public string T3Unit { get; set; }
        public string T4Unit { get; set; }
        public string TSHUnit { get; set; }
        public string FreeT3Unit { get; set; }
        public string FreeT4Unit { get; set; }
        public string FSHUnit { get; set; }
        public string LHUnit { get; set; }
        public string ProlactinUnit { get; set; }
        public string STestosteroneUnit { get; set; }
        public string T3Ref { get; set; }
        public string T4Ref { get; set; }
        public string TSHRef { get; set; }
        public string FreeT3Ref { get; set; }
        public string FreeT4Ref { get; set; }
        public string FSHRef { get; set; }
        public string LHRef { get; set; }
        public string ProlactinRef { get; set; }
        public string STestosteroneRef { get; set; }
        public string Department { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patient { get; set; }
    }
}
