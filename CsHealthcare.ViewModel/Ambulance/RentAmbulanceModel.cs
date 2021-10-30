using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Core;

namespace CsHealthcare.ViewModel.Ambulance
{
  public  class RentAmbulanceModel : AuditModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Vehicle Id")]
        public int VehicleId { get; set; }
        [Display(Name = "Vehicle Name")]
        public string VehicleName { get; set; }
        [Display(Name = "Driver Name")]
        public string Driver { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Display(Name = "From Route")]
        public string FromRoute { get; set; }
        [Display(Name = "To Route")]
        public string ToRoute { get; set; }
        [Display(Name = "Km")]
        public decimal? Kelometer { get; set; }
        [Display(Name = "Party Contact Name")]
        public string PartyContactName { get; set; }
        [Display(Name = " Address")]
        public string PartyAddress { get; set; }
        [Display(Name = " Party Mobile Number")]
        public string PartyMobileNumber { get; set; }
        [Display(Name = " Vehicle For")]
        public string VehicleFor { get; set; }
        [Display(Name = " Amount")]
        public decimal? Amount { get; set; }
        [Display(Name = " Rent Date")]
        public DateTime Date { get; set; }

        public string Voucher { get; set; }
    }
}
