using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.HumanResource
{
   public  partial class TaxConfiguration:AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal StartRange { get; set; }
        public decimal EndRange { get; set; }
        public decimal TaxPercentage { get; set; }



    }
}
