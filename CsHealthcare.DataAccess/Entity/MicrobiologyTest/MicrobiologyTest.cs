using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.MicrobiologyTest
{
    public class MicrobiologyTest
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string SpecimenName { get; set; }
        public string OrganismIsolated { get; set; }
        public string ReferredBy { get; set; }
        public string Culture { get; set; }
        public int PatientAge { get; set; }
        [StringLength(1)]
        public string Ampicillin { get; set; }
        [StringLength(1)]
        public string Amoxycillin { get; set; }
        [StringLength(1)]
        public string Amoxyclav { get; set; }
        [StringLength(1)]
        public string Amikacin { get; set; }
        [StringLength(1)]
        public string Azithromycin { get; set; }
        [StringLength(1)]
        public string Carbinicillin { get; set; }
        [StringLength(1)]
        public string Cefixime { get; set; }
        [StringLength(1)]
        public string Cefotaxime { get; set; }
        [StringLength(1)]
        public string Cefepime { get; set; }
        [StringLength(1)]
        public string Ceftazidime { get; set; }
        [StringLength(1)]
        public string Ceftiaxone { get; set; }
        [StringLength(1)]
        public string Cephalexine { get; set; }
        [StringLength(1)]
        public string Chloramphenicol { get; set; }
        [StringLength(1)]
        public string Cloxacillin { get; set; }
        [StringLength(1)]
        public string Colistin { get; set; }
        [StringLength(1)]

        public string Cefuroxime { get; set; }
        [StringLength(1)]
        public string Cephradine { get; set; }
        [StringLength(1)]
        public string Ciprofloxacin { get; set; }
        [StringLength(1)]
        public string Cotrimoxazole { get; set; }
        [StringLength(1)]
        public string Doxycycline { get; set; }
        [StringLength(1)]
        public string Erythromycin { get; set; }
        [StringLength(1)]
        public string FusidicAcid { get; set; }
        [StringLength(1)]
        public string Gentamycin { get; set; }
        [StringLength(1)]
        public string Imipenem { get; set; }
        [StringLength(1)]
        public string Meropenem { get; set; }
        [StringLength(1)]

        public string NalidexicAcid { get; set; }
        [StringLength(1)]
        public string Netilmycin { get; set; }
        [StringLength(1)]
        public string Nitrofurantion { get; set; }
        [StringLength(1)]
        public string Mecillinam { get; set; }
        [StringLength(1)]
        public string Oxacillin { get; set; }
        [StringLength(1)]
        public string Penicillin { get; set; }
        [StringLength(1)]
        public string Rifampicin { get; set; }
        [StringLength(1)]
        public string Tetracycline { get; set; }
        [StringLength(1)]
        public string Tobramycin { get; set; }
        [StringLength(1)]
        public string Vancomycin { get; set; }
        [StringLength(1)]
        public string PiperacillinOrTazobactam { get; set; }
        [StringLength(1)]
        public string Linezolid { get; set; }
        [StringLength(1)]
        public string Doripenum { get; set; }
        [StringLength(1)]
        public string Tigecycline { get; set; }
        [StringLength(1)]
        public string Ticarcillin { get; set; }
        [StringLength(1)]
        public string Clindamycin { get; set; }
        [StringLength(1)]
        public string Levofloxacin { get; set; }
        [StringLength(1)]
        public string Cepepime { get; set; }

        public DateTime TestDate { get; set; }
       
        [ForeignKey("PatientId")]
        public virtual Patient.Patient Patient { get; set; }
    }
}
