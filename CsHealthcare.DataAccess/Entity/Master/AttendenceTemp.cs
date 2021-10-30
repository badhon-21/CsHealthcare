using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entities.Patient;

namespace CsHealthcare.DataAccess
{
    public class AttendenceTemp
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string Badgenumber { get; set; }

        public DateTime? CheckInTime { get; set; }
    }
}