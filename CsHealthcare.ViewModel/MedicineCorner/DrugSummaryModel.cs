using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.ViewModel.Stock;

namespace CsHealthcare.ViewModel.MedicineCorner
{
    public class DrugCurrentStockModel
    {
        public string DrugId { get; set; }
        public string TradeName { get; set; }

        public string PresentationType { get; set; }
        public string UnitStrength { get; set; }
        public string ManufacturerName { get; set; }

        public int? RemainingQuantity { get; set; }

        public int? ReorderLevel { get; set; }


    }

    public class DrugSearchModel
    {
        public string DrugId { get; set; }
        public string TradeName { get; set; }

        public int? StockInQuantity { get; set; }
        public DateTime StockInDate { get; set; }
        public int? SaleQuantity { get; set; }
        public DateTime StockSaleDate { get; set; }
        public int? DepartmentwiseStockInQuantity { get; set; }
        public DateTime BufferStockDate { get; set; }
        public int? DepartmentwiseStockOutQuantity { get; set; }
        public DateTime HospitalSaleDate { get; set; }
        public int? InPatientDrugSaleQuantity { get; set; }
        public DateTime IPDSaleDate { get; set; }

        public List<DrugStockInModel> DrugStockInModel { get; set; }
        public List<DrugSaleDetailsModel> DrugSaleDetailsModels { get; set; } 

    }
}
