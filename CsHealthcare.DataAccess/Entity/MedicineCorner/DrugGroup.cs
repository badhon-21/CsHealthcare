using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugGroup : AuditableEntity
    {
        public DrugGroup()
        {
            DrugsSelectedGroupses = new HashSet<DrugsSelectedGroups>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public virtual ICollection<DrugsSelectedGroups> DrugsSelectedGroupses { get; set; }

    }
}