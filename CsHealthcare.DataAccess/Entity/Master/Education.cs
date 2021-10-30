using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.ViewModel.HumanResource;

namespace CsHealthcare.DataAccess.Entity.Master
{
    public class Education : AuditableEntity
    {
        public Education()
        {

            PatientInformations = new HashSet<PatientInformation>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string EmployeeInfoId { get; set; }
        [Required]
        [StringLength(100)]
        public string DegreeName { get; set; }

        [StringLength(100)]
        public string Institution { get; set; }

        [StringLength(10)]
        public string Grade { get; set; }
        public decimal CourseDuration { get; set; }
        public int Scale { get; set; }

        [StringLength(4)]
        public string Year { get; set; }
        public virtual ICollection<PatientInformation> PatientInformations { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public virtual EmployeeInfo EmployeeInfo { get; set; }


    }
}