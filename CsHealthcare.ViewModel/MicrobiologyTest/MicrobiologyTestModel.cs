using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MicrobiologyTest
{
    public class MicrobiologyTestModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        //public int pId { get; set; }
        //public int tspecimenId { get; set; }
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Organism Isolated")]
        public string OrganismIsolated { get; set; }
        [Display(Name = "Referred By")]
        public string ReferredBy { get; set; }
        [Display(Name = "Culture")]
        public string Culture { get; set; }
        [Display(Name = "Patient Age")]
        public int PatientAge { get; set; }
        
        [Display(Name = "Specimen Name")]
        public string SpecimenName { get; set; }
        [Display(Name = "Ampicillin")]
        public string Ampicillin { get; set; }
        [Display(Name = "Amoxycillin")]
        public string Amoxycillin { get; set; }
        [Display(Name = "Amoxyclav")]
        public string Amoxyclav { get; set; }
        [Display(Name = "Amikacin")]
        public string Amikacin { get; set; }
        [Display(Name = "Azithromycin")]
        public string Azithromycin { get; set; }
        [Display(Name = "Carbinicillin")]
        public string Carbinicillin { get; set; }
        [Display(Name = "Cefixime")]
        public string Cefixime { get; set; }
        [Display(Name = "Cefotaxime")]
        public string Cefotaxime { get; set; }
        [Display(Name = "Cefepime")]
        public string Cefepime { get; set; }
        [Display(Name = "Ceftazidime")]
        public string Ceftazidime { get; set; }
        [Display(Name = "Ceftiaxone")]
        public string Ceftiaxone { get; set; }
        [Display(Name = "Cephalexine")]
        public string Cephalexine { get; set; }
        [Display(Name = "Chloramphenicol")]
        public string Chloramphenicol { get; set; }
        [Display(Name = "Cloxacillin")]
        public string Cloxacillin { get; set; }
        [Display(Name = "Colistin")]
        public string Colistin { get; set; }
        [Display(Name = "Cefuroxime")]

        public string Cefuroxime { get; set; }
        [Display(Name = "Cephradine")]
        public string Cephradine { get; set; }
        [Display(Name = "Ciprofloxacin")]
        public string Ciprofloxacin { get; set; }
        [Display(Name = "Cotrimoxazole")]
        public string Cotrimoxazole { get; set; }
        [Display(Name = "Doxycycline")]
        public string Doxycycline { get; set; }
        [Display(Name = "Erythromycin")]
        public string Erythromycin { get; set; }
        [Display(Name = "FusidicAcid")]
        public string FusidicAcid { get; set; }
        [Display(Name = "Gentamycin")]
        public string Gentamycin { get; set; }
        [Display(Name = "Imipenem")]
        public string Imipenem { get; set; }
        [Display(Name = "Meropenem")]
        public string Meropenem { get; set; }
        [Display(Name = "NalidexicAcid")]

        public string NalidexicAcid { get; set; }
        [Display(Name = "Netilmycin")]
        public string Netilmycin { get; set; }
        [Display(Name = "Nitrofurantion")]
        public string Nitrofurantion { get; set; }
        [Display(Name = "Mecillinam")]
        public string Mecillinam { get; set; }
        [Display(Name = "Oxacillin")]
        public string Oxacillin { get; set; }
        [Display(Name = "Penicillin")]
        public string Penicillin { get; set; }
        [Display(Name = "Rifampicin")]
        public string Rifampicin { get; set; }
        [Display(Name = "Tetracycline")]
        public string Tetracycline { get; set; }
        [Display(Name = "Tobramycin")]
        public string Tobramycin { get; set; }
        [Display(Name = "Vancomycin")]
        public string Vancomycin { get; set; }
        [Display(Name = "Piperacillin/Tazobactam")]
        public string PiperacillinOrTazobactam { get; set; }
        [Display(Name = "Piperacillin/Tazobactam")]
        public string Linezolid { get; set; }
        [Display(Name = "Doripenum")]
        public string Doripenum { get; set; }
        [Display(Name = "Tigecycline")]
        public string Tigecycline { get; set; }
        [Display(Name = "Ticarcillin")]
        public string Ticarcillin { get; set; }
        [Display(Name = "Clindamycin")]
        public string Clindamycin { get; set; }
        [Display(Name = "Levofloxacin")]
        public string Levofloxacin { get; set; }
        [Display(Name = "Cepepime")]
        public string Cepepime { get; set; }
        public string Culture1 { get; set; }
        public string Culture2 { get; set; }
        public string Culture3 { get; set; }
        public string Culture4 { get; set; }
        public string Culture5 { get; set; }
        public string Culture6 { get; set; }
        public string Culture7 { get; set; }
        public string Culture8 { get; set; }
        public string txtGrowthType { get; set; }
        public string VoucherNumber { get; set; }
        public int TestRequestId { get; set; }
        public DateTime TestDate { get; set; }
    }


    public class MicrobiologyTestReportSummaryModel
    {
        public int PatientId { get; set; }
        public int SpecimenId { get; set; }
        public string PatientName { get; set; }
        public string SpecimenName { get; set; }
        public Boolean TestQuantity { get; set; }
        public string VoucherNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal NoOfProduct { get; set; }
        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }
    }
}
