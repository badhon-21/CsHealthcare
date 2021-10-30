using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Core;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class InPatientDrugSaleReturn:AuditableEntity
    {
        public InPatientDrugSaleReturn()
        {

            InPatientDrugSaleReturnDetails = new HashSet<InPatientDrugSaleReturnDetails>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MemoNo { get; set; }

        [Required]
        [StringLength(50)]
        public string LotNo { get; set; }
        [Required]
        public string PatientCode { get; set; }
        public decimal ReturnPrice { get; set; }
        public decimal ReturnDiscount { get; set; }
        public int ReturnQty { get; set; }
        public decimal ReturnSubTotal { get; set; }

        public DateTime ReturnDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string TxnNo { get; set; }
        public string AdmissionNo { get; set; }
        public virtual ICollection<InPatientDrugSaleReturnDetails> InPatientDrugSaleReturnDetails { get;set; }
        
    }
}
