using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.HumanResource;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
    public partial class EmployeeInfo : AuditableEntity
    {
        public EmployeeInfo()
        {
            Education = new HashSet<Education>();
            CheckInCheckOuts = new List<CheckInCheckOut>();
        }
        [Key]
        [Required]
        public string Id { get; set; }

        [StringLength(100)]
        public string Tag { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string MiddleName { get; set; }
        [StringLength(100)]
        public string FamilyName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [StringLength(100)]
        public string BirthPlace { get; set; }
        [StringLength(50)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string Religion { get; set; }
        [StringLength(20)]
        public string BloodGroup { get; set; }
        [StringLength(100)]
        public string Nationality { get; set; }
        [StringLength(100)]
        public string NationalId { get; set; }
        public string PassportNumber { get; set; }
        [StringLength(100)]
        public string TinNumber { get; set; }

        [StringLength(100)]
        public string FatherName { get; set; }
        [StringLength(100)]
        public string FatherOccupation { get; set; }
        [StringLength(100)]
        public string MotherName { get; set; }
        [StringLength(100)]
        public string MotherOccupation { get; set; }
        [StringLength(20)]
        public string MaritalStatus { get; set; }

        public DateTime? MarriageDate { get; set; }
        [StringLength(100)]
        public string SpouseName { get; set; }
        [StringLength(100)]
        public string SpouseOccupation { get; set; }
        [StringLength(100)]
        public string PresentAddress { get; set; }
        [StringLength(100)]
        public string PermanentAddress { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Mobile { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(50)]
        public string EmployeeDesignationId { get; set; }

        public string DepartmentId { get; set; }

        public int? ShiftId { get; set; }

        [StringLength(50)]
        public string ContractType { get; set; }
        [StringLength(100)]
        public string ContractPeriod { get; set; }
        public DateTime? DateOfJob { get; set; }
        [StringLength(100)]
        public string Photo { get; set; }


        [StringLength(50)]
        public string Badgenumber { get; set; }

        [ForeignKey("EmployeeDesignationId")]
        public EmployeeDesignation EmployeeDesignation { get; set; }
        [ForeignKey("DepartmentId")]
        public DEPARTMENT Department { get; set; }

        [ForeignKey("ShiftId")]
        public Shift Shifts { get; set; }

        public virtual ICollection<Education> Education { get; set; }

        public virtual ICollection<CheckInCheckOut> CheckInCheckOuts { get; set; }
    }
}
