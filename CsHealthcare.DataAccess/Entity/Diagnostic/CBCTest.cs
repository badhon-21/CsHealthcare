using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Diagnostic
{
   public partial class CBCTest
    {

        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }
        [StringLength(100)]
        public string PatientCode { get; set; }
        [StringLength(50)]
        public string ReferanceName { get; set; }
        public string SpecimenName { get; set; }
        public string Haemoglobin { get; set; }
        public string Hematocrit { get; set; }

        public string RedCellsCount { get; set; }
        public string MeanCellVolume { get; set; }
        public string MeanCellHaemoglobin { get; set; }
        public string MeanCellHaemoglobinConcentration { get; set; }
        public string RedCellDistributionWidth { get; set; }
        public string NucleatedRedBloodCells { get; set; }

        public string TotalWbcCount { get; set; }
        public string Neutrophil { get; set; }
        public string Lymphocyte { get; set; }
        public string Monocyte { get; set; }

        public string Eosinophil { get; set; }
        public string Basophil { get; set; }

        public string ImmatureGranulocytes { get; set; }

        public string Neutrophils { get; set; }
        public string Lymphocytes { get; set; }
        public string Monocytes { get; set; }
        public string Eosinophils { get; set; }
        public string Basophils { get; set; }

        public string ImmatureGranulocytess { get; set; }

        public string PlateletsCount { get; set; }
        public string ErythrocyteSedimentationRate { get; set; }


        public string HaemoglobinUnit { get; set; }
        public string HematocritUnit { get; set; }

        public string RedCellsCountUnit { get; set; }
        public string MeanCellVolumeUnit { get; set; }
        public string MeanCellHaemoglobinUnit { get; set; }
        public string MeanCellHaemoglobinConcentrationUnit { get; set; }
        public string RedCellDistributionWidthUnit { get; set; }
        public string NucleatedRedBloodCellsUnit { get; set; }

        public string TotalWbcCountUnit { get; set; }
        public string NeutrophilUnit { get; set; }
        public string LymphocyteUnit { get; set; }
        public string MonocyteUnit { get; set; }

        public string EosinophilUnit { get; set; }
        public string BasophilUnit { get; set; }

        public string ImmatureGranulocytesUnit { get; set; }

        public string NeutrophilsUnit { get; set; }
        public string LymphocytesUnit { get; set; }
        public string MonocytesUnit { get; set; }
        public string EosinophilsUnit { get; set; }
        public string BasophilsUnit { get; set; }

        public string ImmatureGranulocytessUnit { get; set; }

        public string PlateletsCountUnit { get; set; }
        public string ErythrocyteSedimentationRateUnit { get; set; }

        public string HaemoglobinRefer { get; set; }
        public string HematocritRefer { get; set; }

        public string RedCellsCountRefer { get; set; }
        public string MeanCellVolumeRefer { get; set; }
        public string MeanCellHaemoglobinRefer { get; set; }
        public string MeanCellHaemoglobinConcentrationRefer { get; set; }
        public string RedCellDistributionWidthRefer { get; set; }
        public string NucleatedRedBloodCellsRefer { get; set; }

        public string TotalWbcCountRefer { get; set; }
        public string NeutrophilRefer { get; set; }
        public string LymphocyteRefer { get; set; }
        public string MonocyteRefer { get; set; }

        public string EosinophilRefer { get; set; }
        public string BasophilRefer { get; set; }

        public string ImmatureGranulocytesRefer { get; set; }

        public string NeutrophilsRefer { get; set; }
        public string LymphocytesRefer { get; set; }
        public string MonocytesRefer { get; set; }
        public string EosinophilsRefer { get; set; }
        public string BasophilsRefer { get; set; }

        public string ImmatureGranulocytessRefer { get; set; }

        public string PlateletsCountRefer { get; set; }
        public string ErythrocyteSedimentationRateRefer { get; set; }


        [StringLength(200)]
        public string Department { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patient { get; set; }

    }
}
