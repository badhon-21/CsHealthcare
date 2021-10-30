using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.Canteen
{
   public partial class Sells
    {
        public Sells()
        {

            SellsDetails = new HashSet<SellsDetails>();

        }
        [Required]
        public string Id { get; set; }

        public string CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string SellsNo { get; set; }

        public DateTime SellsDate { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal GrandTotal { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public string Note { get; set; }

        public decimal? Discount { get; set; }

        [StringLength(100)]
        public string TransactionType { get; set; }

        [StringLength(100)]
        public string TransactionNumber { get; set; }

        public decimal? GivenAmount { get; set; }

        public decimal? ChangeAmount { get; set; }

        [StringLength(50)]
        public string RecStatus { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public virtual ICollection<SellsDetails> SellsDetails { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
