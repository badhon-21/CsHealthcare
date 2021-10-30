using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess
{
    public class DiseaseCondition : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
    }
}