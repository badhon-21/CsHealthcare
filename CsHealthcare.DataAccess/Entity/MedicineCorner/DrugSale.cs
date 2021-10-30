using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsHealthcare.DataAccess.Core;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class DrugSale : AuditableEntity
    {
        public DrugSale()
        {

            DrugSaleDetails = new HashSet<DrugSaleDetails>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string MemoNo { get; set; }
        [StringLength(250)]
        public string PatientName { get; set; }

        [StringLength(50)]
        public string TxnNo { get; set; }

        [StringLength(50)]
        public string LotId { get; set; }

        public int? PatientId { get; set; }
       
        public decimal? SaleQty { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? SaleDiscount { get; set; }
        public decimal? Vat { get; set; }
        public decimal? SpecialDiscount { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? SaleDateTime { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }
        

        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }


        public virtual ICollection<DrugSaleDetails> DrugSaleDetails { get; set; }
    }
}