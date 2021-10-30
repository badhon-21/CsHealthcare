using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CsHealthcare.ViewModel.Core;
using CsHealthcare.ViewModel.MedicineCorner;

namespace CsHealthcare.ViewModel.Stock
{
    public class DrugStockInModel:AuditModel
    {
        [Display(Name="Id")]
        public int Id { get; set; }

        [Display(Name = "Txn No")]
        public string TxnNo { get; set; }

        [Display(Name = "Lot Id")]
        public string LotId { get; set; }
        [Display(Name = "Drug Manufacturer Id")]
        public int DRUG_MANUFACTURERId { get; set; }
        [Display(Name = "Drug Manufacturer Name")]
        public string DRUG_MANUFACTURERName { get; set; }

        [Display(Name = "DepartmentId")]
        public string DepartmentId { get; set; }

        [Display(Name = "Invoice No")]
        public string InvNo { get; set; }

        [Display(Name = "Dpo Id")]
        public string DpoId { get; set; }
        [Display(Name = "Net Amount")]
        public decimal NetAmount { get; set; }
        [Display(Name = "Vat")]
        public decimal VatAmount { get; set; }
        [Display(Name = "Discount")]
        public decimal DiscountAmount { get; set; }
        [Display(Name = "Amount")]
        public decimal InvAmount { get; set; }

        [Display(Name = "Quantity")]
        public decimal InvQty { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTime InvDate { get; set; }
        [Display(Name = "Record Date")]
        public DateTime? RecordDate { get; set; }

        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; }

       
        public string RecStatus { get; set; }

        
        public string SetUpUser { get; set; }

        public DateTime? SetUpDate { get; set; }

        public List<DrugStockDetailsModel> DrugStockDetailsModels { get; set; }
    }

    public class DrugStockInViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Invoice No")]
        public string InvNo { get; set; }
        [Display(Name = "Lot No")]
        public string LotNo { get; set; }
        [Display(Name = "Amount")]
        public decimal? InvAmount { get; set; }
        [Display(Name = "Total Quantity")]
        public decimal? InvQuantity { get; set; }
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }
        [Display(Name = "Drug Type")]
        public string DrugType { get; set; }
        [Display(Name = "Invoice Date")]
        public DateTime? Date { get; set; }
        public string ManufacturerName { get; set; }
        [Display(Name = "Vat")]
        public decimal VatAmount { get; set; }
        [Display(Name = "Discount")]
        public decimal DiscountAmount { get; set; }
        public List<DrugStockDetailsViewModel> DrugStockDetailsViewModels { get; set; }
    }
    public class FileUploadViewModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }

    public class DrugStockInReportViewModel
    {
        public int? DrugId { get; set; }
        public string DrugName { get; set; }
        public string DrugManufacturerName { get; set; }
        public int? RemainingQuantity { get; set; }
        public DateTime? ExpDate { get; set; }
        public DateTime? MafDate { get; set; }
    }


    public class DrugExpiredReportViewModel
    {
        public int? DrugId { get; set; }
        public string DrugName { get; set; }
        public int? RemainingQuantity { get; set; }
        public DateTime? ExpDate { get; set; }
        public string ManufacturerName { get; set; }

        public int PresentationTypeId { get; set; }

        public string PresentationTypeName { get; set; }
        public string TradeName { get; set; }

        public string GenericName { get; set; }

        public string UnitStrength { get; set; }

    }



}
