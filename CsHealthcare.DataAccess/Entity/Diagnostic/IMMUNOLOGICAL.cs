using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
   public partial class IMMUNOLOGICAL
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }
        [StringLength(100)]
        public string PatientCode { get; set; }
        [StringLength(50)]
        public string ReferanceName { get; set; }
        public string SpecimenName { get; set; }
        public string βhCGUnit { get; set; }
        public string PSAUnit { get; set; }
        public string SFerritinUnit { get; set; }
        public string TIgEUnit { get; set; }
        public string βhCGRef { get; set; }
        public string PSARef { get; set; }
        public string SFerritinRef { get; set; }
        public string TIgERef { get; set; }
        public string βhCG { get; set; }
        public string PSA { get; set; }
        public string SFerritin { get; set; }
        public string TIgE { get; set; }
        public string Department { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patient { get; set; }
    }
}
