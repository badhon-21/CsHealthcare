using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public partial class InsurancePlan:AuditableEntity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string InsuranceCompanyId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [ForeignKey("InsuranceCompanyId")]
       public virtual InsuranceCompany InsuranceCompany { get; set; }

    }
}
