using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
   public class ENDOCRINOLOGYModel
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
        [Display(Name = "Department Name")]
        public string Department { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

    }
}
