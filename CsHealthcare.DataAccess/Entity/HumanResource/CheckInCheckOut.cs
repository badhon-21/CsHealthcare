using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entity.HumanResource;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
    public partial class CheckInCheckOut : AuditableEntity
    {
        public CheckInCheckOut()
        {
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string EmployeeId { get; set; }

        public DateTime? CheckInDateTime { get; set; }

        public DateTime? CheckOutDateTime { get; set; }

        public decimal? TotalHours { get; set; }

        public string Remarks { get; set; }

        [ForeignKey("EmployeeId")]
        public EmployeeInfo EmployeeInfo { get; set; }
    }
}