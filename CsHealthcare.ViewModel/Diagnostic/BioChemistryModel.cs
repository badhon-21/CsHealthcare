using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
   public class BioChemistryModel
    {
        [Display(Name="Id")]
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
        [Display(Name = "Blood Glucose Random")]
        public string BloodGlucoseRandom { get; set; }
        [Display(Name = "Blood Glucose Fasti ")]
        public string BloodGlucoseFasting { get; set; }
        [Display(Name = "2 hrs after 75gm Glucose ")]
        public string Twohrsafter75gmGlucose { get; set; }
        [Display(Name = "Blood Glucose 2 hrs ABF")]
        public string BloodGlucoseTwohrsABF { get; set; }
        public string BloodGlucoseRandomRef { get; set; }
        [Display(Name = "Urea")]
        public string Urea { get; set; }
        [Display(Name = "S.Creatinine")]
        public string SCreatinine { get; set; }
        [Display(Name = "S.Uric Acid ")]
        public string SUricAcid { get; set; }
        [Display(Name = "S. AST (SGOT)")]
        public string SAST { get; set; }
        [Display(Name = "S. ALT (SGPT)")]
        public string SALT { get; set; }
        [Display(Name = "S. Alkaline Phosphatase  ")]
        public string SAlkalinePhosphatase { get; set; }
        [Display(Name = "S.Alkaline Phosphatase Protein")]
        public string SAlkalinePhosphataseProtein { get; set; }
        [Display(Name = "S.Calcium")]
        public string SCalcium { get; set; }
        [Display(Name = "S.Iron")]
        public string SIron { get; set; }
        [Display(Name = "S. TIBC")]
        public string STIBC { get; set; }
        [Display(Name = "S.Inorganic Phosphate")]
        public string SInorganicPhosphate { get; set; }
        [Display(Name = "S. Magnesium")]
        public string SMagnesium { get; set; }
        [Display(Name = "Sodium")]
        public string Sodium { get; set; }
        [Display(Name = "Potassium")]
        public string Potassium { get; set; }
        [Display(Name = "Chloride")]
        public string Chloride { get; set; }
        [Display(Name = "Total Carbondioxaid")]
        public string TotalCarbondioxaid { get; set; }
        [Display(Name = "S.Cholesterol")]
        public string SCholesterol { get; set; }
        [Display(Name = "S.Triglycerides")]
        public string STriglycerides { get; set; }
        [Display(Name = "S.HDL Cholesterol")]
        public string SHDLCholesterol { get; set; }
        [Display(Name = "Troponin I")]
        public string TroponinI { get; set; }
        public string SBilirubin{ get; set; }
        public string BloodGlucoseRandomUnit { get; set; }
        public string BloodGlucoseFastingUnit { get; set; }

        public string Twohrsafter75gmGlucoseUnit { get; set; }
        public string BloodGlucoseTwohrsABFUnit { get; set; }
        public string SBilirubinUnit { get; set; }
        public string UreaUnit { get; set; }
        public string SCreatinineUnit { get; set; }
        public string SUricAcidUnit { get; set; }
        public string SASTUnit { get; set; }
        public string SALTUnit { get; set; }
        public string SAlkalinePhosphataseUnit { get; set; }
        public string SAlkalinePhosphataseProteinUnit { get; set; }
        public string SCalciumUnit { get; set; }
        public string SIronUnit { get; set; }
        public string STIBCUnit { get; set; }
        public string SInorganicPhosphateUnit { get; set; }
        public string SMagnesiumUnit { get; set; }
        public string SodiumUnit { get; set; }
        public string PotassiumUnit { get; set; }
        public string ChlorideUnit { get; set; }
        public string TotalCarbondioxaidUnit { get; set; }
        public string SCholesterolUnit { get; set; }
        public string STriglyceridesUnit { get; set; }
        public string SHDLCholesterolUnit { get; set; }
        public string TroponinIUnit { get; set; }
       
        public string Twohrsafter75gmGlucoseRef { get; set; }
        public string BloodGlucoseTwohrsABFRef { get; set; }
        public string UreaRef { get; set; }
        public string SBilirubinRef { get; set; }
        public string SCreatinineRef { get; set; }
        public string SUricAcidRef { get; set; }
        public string SASTRef { get; set; }
        public string SALTRef { get; set; }
        public string SAlkalinePhosphataseRef { get; set; }
        public string SAlkalinePhosphataseProteinRef { get; set; }
        public string SCalciumRef { get; set; }
        public string BloodGlucoseFastingRef { get; set; }
        public string SIronRef { get; set; }
        public string STIBCRef { get; set; }
        public string SInorganicPhosphateRef { get; set; }
        public string SMagnesiumRef { get; set; }
        public string SodiumRef { get; set; }
        public string PotassiumRef { get; set; }
        public string ChlorideRef { get; set; }
        public string TotalCarbondioxaidRef { get; set; }
        public string SCholesterolRef { get; set; }
        public string STriglyceridesRef { get; set; }
        public string SHDLCholesterolRef { get; set; }
        public string TroponinIRef { get; set; }
        [Display(Name = "Department Name")]
        public string Department { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}
