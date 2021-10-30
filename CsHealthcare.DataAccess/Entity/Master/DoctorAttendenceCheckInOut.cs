using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Patient;

namespace CsHealthcare.DataAccess
{
    public class DoctorAttendenceCheckInOut
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DocId { get; set; }

        public DateTime? ChkInTime { get; set; }
        [StringLength(50)]
        public string Remarks { get; set; }

    }
}