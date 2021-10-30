using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.Ambulance
{
  public partial  class RentAmbulance : AuditableEntity
    {

        public int Id { get; set; }

        public int VehicleId { get; set; }
        [StringLength(100)]
        public string VehicleName { get; set; }
        [StringLength(100)]
        public string Driver { get; set; }
        [StringLength(20)]
        public string Mobile { get; set; }
        [StringLength(100)]
        public string FromRoute { get; set; }
        [StringLength(100)]
        public string ToRoute { get; set; }
        public decimal? Kelometer { get; set; }
        [StringLength(100)]
        public string PartyContactName { get; set; }
        [StringLength(200)]
        public string PartyAddress { get; set; }
        [StringLength(20)]
        public string PartyMobileNumber { get; set; }
        [StringLength(20)]
        public string VehicleFor { get; set; }
        public decimal? Amount { get; set; }
        public DateTime Date { get; set; }

        public string Voucher { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

    }
}
