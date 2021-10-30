using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
 public partial class BioChemistry
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }
        [StringLength(100)]
        public string PatientCode { get; set; }
        [StringLength(50)]
        public string ReferanceName { get; set; }
        public string SpecimenName { get; set; }
        public string BloodGlucoseRandom { get; set; }
        public string BloodGlucoseFasting { get; set; }
        public string Twohrsafter75gmGlucose { get; set; }
        public string BloodGlucoseTwohrsABF { get; set; }
        public string Urea { get; set; }
        public string SBilirubin { get; set; }
        public string SCreatinine { get; set; }
        public string SUricAcid  { get; set; }
        public string SAST { get; set; }
        public string SALT { get; set; }
        public string SAlkalinePhosphatase   { get; set; }
        public string SAlkalinePhosphataseProtein{ get; set; }
        public string SCalcium { get; set; }
        public string SIron { get; set; }
        public string STIBC { get; set; }
        public string SInorganicPhosphate  { get; set; }
        public string SMagnesium { get; set; }
        public string Sodium { get; set; }
        public string Potassium { get; set; }
        public string Chloride { get; set; }
        public string TotalCarbondioxaid { get; set; }
        public string SCholesterol { get; set; }
        public string STriglycerides {get; set; }
        public string SHDLCholesterol  { get; set; }
        public string TroponinI { get; set; }


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
        public string BloodGlucoseRandomRef { get; set; }
        public string BloodGlucoseFastingRef { get; set; }
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
        public string Department { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patient { get; set; }

    }
}
