using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugsSelectedGroups : AuditableEntity
    {
        [Key]
        public string Id { get; set; }

        public int DrugId { get; set; }

        [StringLength(100)]
        public string DrugGroupId { get; set; }

        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }

        [ForeignKey("DrugGroupId")]
        public virtual DrugGroup DrugsGroup { get; set; }
    }
}