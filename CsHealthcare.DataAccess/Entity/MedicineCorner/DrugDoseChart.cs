using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugDoseChart : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public int DrugId { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string Dose { get; set; }
        public string Duration { get; set; }
        public string Advice { get; set; }

        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }
    }
}