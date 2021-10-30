using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.DataAccess.Entity.MedicineCorner
{
    public class InPatientDrugSaleReturnDetails
    {
        [Key]
        public int Id { get;set; }
        public int ReturnQty { get; set; }
        public decimal ReturnPrice { get; set; }
        public int InPatientDrugSaleReturnId { get; set; }
        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public virtual DRUG Drug { get; set; }
        [ForeignKey("InPatientDrugSaleReturnId")]
        public virtual InPatientDrugSaleReturn InPatientDrugSaleReturn { get; set; }
    }
}
