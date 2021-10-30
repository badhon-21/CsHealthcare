using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Master
{
    public class FamilyTree : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
    }
}