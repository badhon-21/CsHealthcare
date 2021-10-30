using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public partial class InsuranceCompany:AuditableEntity
    {
       public InsuranceCompany()
       {
            Insurance = new HashSet<InsurancePlan>();
        }
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }


        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Website { get; set; }

        public virtual ICollection<InsurancePlan> Insurance { get; set; }


    }
}
