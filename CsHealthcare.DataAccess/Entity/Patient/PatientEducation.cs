using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class PatientEducation
    {
        [Key]
      
        public int Id { get; set; }
       
        [Required]
        [StringLength(100)]
        public string DegreeName { get; set; }

    }
}
