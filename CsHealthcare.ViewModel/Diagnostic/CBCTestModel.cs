using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.Diagnostic
{
   public class CBCTestModel
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
        [Display(Name = "Haemoglobin")]
        public string Haemoglobin { get; set; }
        [Display(Name = "Hematocrit")]
        public string Hematocrit { get; set; }
        [Display(Name = "Red Cells Count")]
        public string RedCellsCount { get; set; }
        [Display(Name = "Mean Cell Volume")]
        public string MeanCellVolume { get; set; }
        [Display(Name = "Mean Cell Haemoglobin")]
        public string MeanCellHaemoglobin { get; set; }
        [Display(Name = "Mean Cell Haemoglobin Concentration")]
        public string MeanCellHaemoglobinConcentration { get; set; }
        [Display(Name = "Red Cell Distribution Width")]
        public string RedCellDistributionWidth { get; set; }
        [Display(Name = "Nucleated Red Blood Cells")]
        public string NucleatedRedBloodCells { get; set; }
        [Display(Name = "Total WBC Count")]
        public string TotalWbcCount { get; set; }
        [Display(Name = "Neutrophil")]
        public string Neutrophil { get; set; }
        [Display(Name = "Lymphocyte")]
        public string Lymphocyte { get; set; }
        [Display(Name = "Monocyte")]
        public string Monocyte { get; set; }
        [Display(Name = "Eosinophil")]
        public string Eosinophil { get; set; }
        [Display(Name = "Basophil")]
        public string Basophil { get; set; }
        [Display(Name = "Immature Granulocytes")]

        public string ImmatureGranulocytes { get; set; }
        [Display(Name = "Neutrophils %")]
        public string Neutrophils { get; set; }
        [Display(Name = "Lymphocytes %")]
        public string Lymphocytes { get; set; }
        [Display(Name = "Monocytes %")]
        public string Monocytes { get; set; }
        [Display(Name = "Eosinophils %")]
        public string Eosinophils { get; set; }
        [Display(Name = "Basophils %")]
        public string Basophils { get; set; }
        [Display(Name = "Immature Granulocytes %")]
        public string ImmatureGranulocytess { get; set; }
        [Display(Name = "Platelets Count")]
        public string PlateletsCount { get; set; }
        [Display(Name = "Erythrocyte Sedimentation Rate")]
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

        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Department Name")]
        public string Department { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}
