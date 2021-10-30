using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.HumanResource
{
 public   class ItemStockOutModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Memo No")]
        public string MemoNo { get; set; }
        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Purpose")]
        public string Purpose { get; set; }
        [Display(Name = "Total Qty")]
        public decimal? TotalQty { get; set; }
        [Display(Name = "Purpose By")]
        public string PurposeBy { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public List<ItemStockOutDetailsModel> ItemStockOutDetailsModel { get; set; }
    }

    public class ItemStockOutViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Memo No")]
        public string MemoNo { get; set; }
     
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Purpose")]
        public string Purpose { get; set; }
        [Display(Name = "Total Qty")]
        public decimal? TotalQty { get; set; }
        [Display(Name = "Purpose By")]
        public string PurposeBy { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

      
    }
}
