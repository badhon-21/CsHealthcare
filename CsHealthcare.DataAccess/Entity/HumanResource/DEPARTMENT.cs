using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.Store;

namespace CsHealthcare.DataAccess.HumanResource 
{
    public partial class DEPARTMENT:AuditableEntity
    {
        public DEPARTMENT()
        {
            DepartmentDetailsForItem =new HashSet<DepartmentDetailsForItem>();
        }

        [Key]
        public string Id { get; set; }

        [StringLength(100)]
       public string Name { get; set; }

       [StringLength(250)]
       public string Address { get; set; }

        public virtual ICollection<DepartmentDetailsForItem> DepartmentDetailsForItem { get; set; }
  

    }
}

