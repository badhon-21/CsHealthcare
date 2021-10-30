using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
  public  class RETestModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Code")]
        public string PatientCode { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Specimen Name")]
        public string SpecimenName { get; set; }

        [Display(Name = "Referance Name")]
        public string ReferanceName { get; set; }
        [Display(Name = "Colour")]
        public string Colour { get; set; }
        [Display(Name = "Turbidity")]
        public string Turbidity { get; set; }
        [Display(Name = "Sediment")]
        public string Sediment { get; set; }
        [Display(Name = "Clarity")]
        public string Clarity { get; set; }
        [Display(Name = "Specificgravity")]
        public string Specificgravity { get; set; }
        [Display(Name = "PH")]
        public string PH { get; set; }
        [Display(Name = "Protein")]
        public string Protein { get; set; }
        [Display(Name = "Glucose")]
        public string Glucose { get; set; }
        [Display(Name = "Ketone Body")]
        public string Ketones { get; set; }
        [Display(Name = "Bilirubin")]
        public string Bilirubin { get; set; }
        [Display(Name = "Urobilinogen")]
        public string Urobilinogen { get; set; }
        [Display(Name = "Nitrite")]
        public string Nitrite { get; set; }
        [Display(Name = "Pluscells/WBC")]
        public string Puscells { get; set; }
        [Display(Name = "EpithelialCells")]
        public string EpithelialCells { get; set; }
        [Display(Name = "Red Blood Cell")]
        public string RedBloodCell { get; set; }
        [Display(Name = "Hyaline Cast")]
        public string HyalineCast { get; set; }
        [Display(Name = "Granular Cast")]
        public string GranularCast { get; set; }
        [Display(Name = "WBC Cast")]
        public string WbcCast { get; set; }
        [Display(Name = "RBC Cast")]
        public string RbcCast { get; set; }
        [Display(Name = "Calcium Oxalate")]
        public string CalciumOxalate { get; set; }
        [Display(Name = "Amor Phosphate")]
        public string Amorphosphate { get; set; }
        [Display(Name = "Patient Id")]
        public string YeastCandida { get; set; }
        [Display(Name = "Trichomonas Vaginalis")]
        public string TrichomonasVaginalis { get; set; }
        [Display(Name = "Uric Acid")]
        public string UricAcid { get; set; }
        [Display(Name = "Triple Phosphate")]
        public string TriplePhosphate { get; set; }
        [Display(Name = "Spermatozoa")]
        public string Spermatozoa { get; set; }
        [Display(Name = "Crystals")]
        public string Crystals { get; set; }
        [Display(Name = "Others")]
        public string Others { get; set; }
        [Display(Name = "Albumin")]
        public string Albumin { get; set; }

        [Display(Name = "Blood")]
        public string Blood { get; set; }

        public string ColourUnit { get; set; }
        public string ClarityUnit { get; set; }
        public string TurbidityUnit { get; set; }

        public string SedimentUnit { get; set; }
        public string AlbuminUnit { get; set; }
        public string SpecificgravityUnit { get; set; }
        public string PHUnit { get; set; }
        public string ProteinUnit { get; set; }
        public string GlucoseUnit { get; set; }
        public string KetonesUnit { get; set; }
        public string BloodUnit { get; set; }
        public string BilirubinUnit { get; set; }

        public string UrobilinogenUnit { get; set; }
        public string NitriteUnit { get; set; }
        public string PuscellsUnit { get; set; }
        public string EpithelialCellsUnit { get; set; }
        public string CrystalsUnit { get; set; }
        public string RedBloodCellUnit { get; set; }
        public string HyalineCastUnit { get; set; }
        public string GranularCastUnit { get; set; }
        public string WbcCastUnit { get; set; }
        public string RbcCastUnit { get; set; }
        public string CalciumOxalateUnit { get; set; }
        public string UricAcidUnit { get; set; }
        public string TriplePhosphateUnit { get; set; }
        public string AmorphosphateUnit { get; set; }
        public string YeastCandidaUnit { get; set; }
        public string TrichomonasVaginalisUnit { get; set; }
        public string SpermatozoaUnit { get; set; }
        public string OthersUnit { get; set; }
        public string ColourRefer { get; set; }
        public string ClarityRefer { get; set; }
        public string TurbidityRefer { get; set; }

        public string SedimentRefer { get; set; }
        public string AlbuminRefer { get; set; }
        public string SpecificgravityRefer { get; set; }
        public string PHRefer { get; set; }
        public string ProteinRefer { get; set; }
        public string GlucoseRefer { get; set; }
        public string KetonesRefer { get; set; }
        public string BloodRefer { get; set; }
        public string BilirubinRefer { get; set; }

        public string UrobilinogenRefer { get; set; }
        public string NitriteRefer { get; set; }
        public string PuscellsRefer { get; set; }
        public string EpithelialCellsRefer { get; set; }
        public string CrystalsRefer { get; set; }
        public string RedBloodCellRefer { get; set; }
        public string HyalineCastRefer { get; set; }
        public string GranularCastRefer { get; set; }
        public string WbcCastRefer { get; set; }
        public string RbcCastRefer { get; set; }
        public string CalciumOxalateRefer { get; set; }
        public string UricAcidRefer { get; set; }
        public string TriplePhosphateRefer { get; set; }
        public string AmorphosphateRefer { get; set; }
        public string YeastCandidaRefer { get; set; }
        public string TrichomonasVaginalisRefer { get; set; }
        public string SpermatozoaRefer { get; set; }
        public string OthersRefer { get; set; }
       [Display(Name="Department Name")]
        public string Department { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}
