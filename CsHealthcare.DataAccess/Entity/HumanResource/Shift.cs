using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Doctor;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public partial class Shift : AuditableEntity
    {
        public Shift()
        {
            DoctorInformations = new HashSet<DoctorInformation>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(20)]
        public string MorningStart { get; set; }

        [StringLength(20)]
        public string MorningEnd { get; set; }

        [StringLength(20)]
        public string EveningStart { get; set; }

        [StringLength(20)]
        public string EveningEnd { get; set; }

        [StringLength(20)]
        public string NightStart { get; set; }

        [StringLength(20)]
        public string NightEnd { get; set; }

        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }

        public virtual ICollection<DoctorInformation> DoctorInformations { get; set; }
    }
}
