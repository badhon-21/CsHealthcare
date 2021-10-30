using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
    public partial class RETest
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }
        [StringLength(100)]
        public string PatientCode { get; set; }
        [StringLength(50)]
        public string ReferanceName { get; set; }
        public string SpecimenName { get; set; }
        public string Colour { get; set; }
        public string Clarity { get; set; }
        public string Turbidity { get; set; }

        public string Sediment { get; set; }
        public string Albumin { get; set; }
        public string Specificgravity { get; set; }
        public string PH { get; set; }
        public string Protein { get; set; }
        public string Glucose { get; set; }
        public string Ketones { get; set; }
        public string Blood { get; set; }
        public string Bilirubin { get; set; }

        public string Urobilinogen { get; set; }
        public string Nitrite { get; set; }
        public string Puscells { get; set; }
        public string EpithelialCells { get; set; }
        public string Crystals { get; set; }
        public string RedBloodCell { get; set; }
        public string HyalineCast { get; set; }
        public string GranularCast { get; set; }
        public string WbcCast { get; set; }
        public string RbcCast { get; set; }
        public string CalciumOxalate { get; set; }
        public string UricAcid { get; set; }
        public string TriplePhosphate { get; set; }
        public string Amorphosphate { get; set; }
        public string YeastCandida { get; set; }
        public string TrichomonasVaginalis { get; set; }
        public string Spermatozoa { get; set; }
        public string Others { get; set; }

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
        [StringLength(200)]
        public string Department { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patient { get; set; }
    }
}
