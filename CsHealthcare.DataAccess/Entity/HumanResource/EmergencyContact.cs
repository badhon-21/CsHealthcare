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
   public partial class EmergencyContact:AuditableEntity
    {
        [Key]
        public string Id { get; set; }

        public string EmployeeInfoId { get; set; }
        [StringLength(50)]
        public string RefferenceId { get; set; }
        [StringLength(50)]
        public string ContactName1 { get; set; }
        [StringLength(50)]
        public string Relationship1 { get; set; }

        [StringLength(200)]
        public string Address1 { get; set; }
        [StringLength(50)]
        public string Homephone1 { get; set; }
        [StringLength(50)]
        public string Workphone1{ get; set; }

        [StringLength(50)]
        public string Cellphone1 { get; set; }
        [StringLength(50)]
        public string ContactName2 { get; set; }
        [StringLength(50)]
        public string Relationship2 { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string Homephone2 { get; set; }
        [StringLength(50)]
        public string Workphone2 { get; set; }
        [StringLength(50)]
        public string Cellphone2 { get; set; }

        [StringLength(50)]
        public string PhysicianName{ get; set; }
        [StringLength(200)]
        public string PhysicianAddress { get; set; }

        [StringLength(50)]
        public string PhysicianContactNo { get; set; }

        [StringLength(2)]
        public string RefferenceType { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}
