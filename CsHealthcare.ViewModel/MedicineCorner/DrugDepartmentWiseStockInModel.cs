using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
  public  class DrugDepartmentWiseStockInModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Memo No")]
        public string MemoNo { get; set; }
        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Drug Id")]
        public int? DrugId { get; set; }
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }
        [Display(Name = "Transfer Qty")]
        public int? TransferQty { get; set; }
        [Display(Name = "Total Qty")]
        public int? TotalQty { get; set; }
        [Display(Name = "Remaining Quantity")]
        public int? RemainingQuantity { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        public List<DrugDepartmentWiseStockInDetailsModel> DrugDepartmentWiseStockInDetailsModel { get; set; }
    }
}
