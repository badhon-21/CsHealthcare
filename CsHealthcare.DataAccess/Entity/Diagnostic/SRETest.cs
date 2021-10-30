using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
  public partial class SRETest
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
        public string Consistency{ get; set; }

        public string Mucus { get; set; }
        public string Blood { get; set; }
        public string Reaction { get; set; }
        public string ReducingSubstance { get; set; }
        public string OccultBloodTest { get; set; }
        public string PusCells { get; set; }
        
        public string RedBloodCells { get; set; }
        public string Macrophage { get; set; }
        public string VegetableCells { get; set; }
        public string StarchGranules { get; set; }

        public string MuscleFibres { get; set; }
        public string FatGlobules { get; set; }

        public string Ova { get; set; }

        public string Protozoa { get; set; }
        public string Cysts { get; set; }
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
        [StringLength(200)]
        public string Department { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patient { get; set; }

    }
}
