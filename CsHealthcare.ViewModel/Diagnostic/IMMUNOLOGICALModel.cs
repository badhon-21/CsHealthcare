using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
    public class IMMUNOLOGICALModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }
        [Display(Name = "Specimen Name")]
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
        [Display(Name = "Department Name")]
        public string Department { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}
