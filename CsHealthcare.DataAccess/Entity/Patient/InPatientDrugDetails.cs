using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Entity.MedicineCorner;

namespace CsHealthcare.DataAccess.Entity.Patient
{
    public class InPatientDrugDetails
    {
        public int Id { get; set; }
        public int? DrugId { get; set; }
        public int? InPatientDrugId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? SaleDiscount { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("DrugSaleId")]
        public virtual InPatientDrug InPatientDrug { get; set; }
        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }
    }
}
