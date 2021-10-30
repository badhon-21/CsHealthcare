using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
   public class SEROLOGYModel
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
        public string CRP { get; set; }
        public string RA { get; set; }
        public string ASO { get; set; }
        public string HBsAg { get; set; }
        public string BloodGroup { get; set; }
        public string RhFactor { get; set; }
        public string UrineforPregnancyTest { get; set; }
        public string VDRL { get; set; }
        public string TO { get; set; }
        public string TH { get; set; }
        public string AH { get; set; }
        public string BH { get; set; }
        public string AO { get; set; }
        public string BO { get; set; }

        public string CRPUnit { get; set; }
        public string RAUnit { get; set; }
        public string ASOUnit { get; set; }
        public string HBsAgUnit { get; set; }
        public string BloodGroupUnit { get; set; }
        public string RhFactorUnit { get; set; }
        public string UrineforPregnancyTestUnit { get; set; }
        public string VDRLUnit { get; set; }
        public string TOUnit { get; set; }
        public string THUnit { get; set; }
        public string AHUnit { get; set; }
        public string BHUnit { get; set; }
        public string AOUnit { get; set; }
        public string BOUnit { get; set; }

        public string CRPRef { get; set; }
        public string RARef { get; set; }
        public string ASORef { get; set; }
        public string HBsAgRef { get; set; }
        public string BloodGroupRef { get; set; }
        public string RhFactorRef { get; set; }
        public string UrineforPregnancyTestRef { get; set; }
        public string VDRLRef { get; set; }
        public string TORef { get; set; }
        public string THRef { get; set; }
        public string AHRef { get; set; }
        public string BHRef { get; set; }
        public string AORef { get; set; }
        public string BORef { get; set; }

        [Display(Name = "Department Name")]
        public string Department { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}
