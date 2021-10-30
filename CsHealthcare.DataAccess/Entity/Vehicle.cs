using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity
{
    public partial class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string VehicleId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
