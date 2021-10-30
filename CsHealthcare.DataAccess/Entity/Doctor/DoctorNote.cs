using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Doctor
{
    public class DoctorNote : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Note { get; set; }
    }
}