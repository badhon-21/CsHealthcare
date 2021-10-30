using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class DrugDepartmentWiseStockOutModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "MemoNo")]
        public string MemoNo { get; set; }
        [Display(Name = "LotNo")]
        public string LotNo { get; set; }
        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Total Qty")]
        public int? TotalQty { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public List<DrugDepartmentWiseStockOutDetailsModel> DrugDepartmentWiseStockOutDetailsModel { get; set; }
    }
    public class DrugDepartmentWiseStockOutSummaryModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "MemoNo")]
        public string MemoNo { get; set; }
        [Display(Name = "LotNo")]
        public string LotNo { get; set; }

        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }

        [Display(Name = "Department Id")]
        public string DepartmentName { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Total Qty")]
        public int? TotalQty { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

    }
}
