using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
   public class SRETestModel
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
        [Display(Name = "Consistency")]
        public string Consistency { get; set; }
        [Display(Name = "Mucus")]
        public string Mucus { get; set; }
        [Display(Name = "Blood")]
        public string Blood { get; set; }
        [Display(Name = "Reaction")]
        public string Reaction { get; set; }
        [Display(Name = "Reducing Substance")]
        public string ReducingSubstance { get; set; }
        [Display(Name = "Occult Blood Test")]
        public string OccultBloodTest { get; set; }
        [Display(Name = "Pus Cells")]
        public string PusCells { get; set; }
        [Display(Name = "Red Blood Cells")]
        public string RedBloodCells { get; set; }
        [Display(Name = "Macrophage")]
        public string Macrophage { get; set; }
        [Display(Name = "Vegetable Cells")]
        public string VegetableCells { get; set; }
        [Display(Name = "Starch Granules")]
        public string StarchGranules { get; set; }
        [Display(Name = "Muscle Fibres")]

        public string MuscleFibres { get; set; }
        [Display(Name = "Fat Globules")]
        public string FatGlobules { get; set; }
        [Display(Name = "Ova")]
        public string Ova { get; set; }
        [Display(Name = "Protozoa")]
        public string Protozoa { get; set; }
        [Display(Name = "Cysts")]
        public string Cysts { get; set; }
        [Display(Name = "Others")]
        public string Others { get; set; }

        public string ColourUnit { get; set; }
        public string ConsistencyUnit { get; set; }

        public string MucusUnit { get; set; }
        public string BloodUnit { get; set; }
        public string ReactionUnit { get; set; }
        public string ReducingSubstanceUnit { get; set; }
        public string OccultBloodTestUnit { get; set; }
        public string PusCellsUnit { get; set; }

        public string RedBloodCellsUnit { get; set; }
        public string MacrophageUnit { get; set; }
        public string VegetableCellsUnit { get; set; }
        public string StarchGranulesUnit { get; set; }

        public string MuscleFibresUnit { get; set; }
        public string FatGlobulesUnit { get; set; }

        public string OvaUnit { get; set; }

        public string ProtozoaUnit { get; set; }
        public string CystsUnit { get; set; }
        public string OthersUnit { get; set; }

        public string ColourRefer { get; set; }
        public string ConsistencyRefer { get; set; }

        public string MucusRefer { get; set; }
        public string BloodRefer { get; set; }
        public string ReactionRefer { get; set; }
        public string ReducingSubstanceRefer { get; set; }
        public string OccultBloodTestRefer { get; set; }
        public string PusCellsRefer { get; set; }

        public string RedBloodCellsRefer { get; set; }
        public string MacrophageRefer { get; set; }
        public string VegetableCellsRefer { get; set; }
        public string StarchGranulesRefer { get; set; }

        public string MuscleFibresRefer { get; set; }
        public string FatGlobulesRefer { get; set; }

        public string OvaRefer { get; set; }

        public string ProtozoaRefer { get; set; }
        public string CystsRefer { get; set; }
        public string OthersRefer { get; set; }
        [Display(Name="Department Name")]
        public string Department { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}
