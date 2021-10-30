using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Canteen
{
   public partial class Customer
    {
       public Customer()
       {
           Sells = new HashSet<Sells>();
       }

       public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string CardId { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string AddressOne { get; set; }
        [StringLength(100)]
        public string AddressTwo { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        public virtual ICollection<Sells> Sells { get; set; }

    }
}
