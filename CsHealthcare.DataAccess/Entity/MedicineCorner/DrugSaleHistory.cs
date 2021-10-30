using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.Patient;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public partial class DrugSaleHistory
    {
        public DrugSaleHistory()
        {

            DrugSaleDetailsHistory = new HashSet<DrugSaleDetailsHistory>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string MemoNo { get; set; }

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



        [ForeignKey("PatientId")]
        public virtual PatientInformation PatientInformation { get; set; }


        public virtual ICollection<DrugSaleDetailsHistory> DrugSaleDetailsHistory { get; set; }
    }
}
