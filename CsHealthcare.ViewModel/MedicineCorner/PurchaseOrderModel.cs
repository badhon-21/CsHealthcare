using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class PurchaseOrderModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "DRUG MANUFACTURER Id")]
        public int DRUG_MANUFACTURERId { get; set; }

        [Display(Name = "DRUG MANUFACTURER Name")]
        public string DRUG_MANUFACTURERName { get; set; }

        [Display(Name = "Memo No")]
        public string MemoNo { get; set; }

        [Display(Name = "Txn No")]
        public string TxnNo { get; set; }

        [Display(Name = "Lot Id")]
        public string LotId { get; set; }

        [Display(Name = "Total Quantity")]
        public decimal TotalQty { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        public DateTime RecordDate { get; set; }

        public List<PurchaseOrderDetailsModel> PurchaseOrderDetailsModels { get; set; }
    }

    public class PurchaseOrderViewModel
    {
        public int id { get; set; }
        public string DrugName { get; set; }
        public string DrugPresentationTypeName { get; set; }
        public string UnitStrength { get; set; }
        public int? ReOdrerlevel { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RemainingQuantity { get; set; }
        public decimal? UnitPrice { get; set; }
        
        public decimal? SubTotalPrice { get; set; }
    }
}
