using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.HumanResource;

namespace CsHealthcare.DataAccess.Entity.Stock
{
    public partial class DrugStockIn:AuditableEntity
    {
        public DrugStockIn()
        {

            DrugStockDetails = new HashSet<DrugStockDetails>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string TxnNo { get; set; }

        [Required]
        [StringLength(50)]
        public string LotId { get; set; }

        public int DRUG_MANUFACTURERId { get; set; }
        //public string DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string InvNo { get; set; }

        [StringLength(50)]
        public string DpoId { get; set; }

        public decimal InvAmount { get; set; }

        public decimal InvQty { get; set; }

        public DateTime InvDate { get; set; }

       
        public decimal NetAmount { get; set; }
      
        public decimal VatAmount { get; set; }
     
        public decimal DiscountAmount { get; set; }

        public DateTime? RecordDate { get; set; }

        [Required]
        [StringLength(20)]
        public string PaymentStatus { get; set; }

        [StringLength(1)]
        public string RecStatus { get; set; }

        [StringLength(50)]
        public string SetUpUser { get; set; }

        public DateTime? SetUpDate { get; set; }

        public virtual DRUG_MANUFACTURER DRUG_MANUFACTURER { get; set; }
        
        public virtual ICollection<DrugStockDetails> DrugStockDetails { get; set; }
    }
}
