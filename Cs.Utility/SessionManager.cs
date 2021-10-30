using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;
using CsHealthcare.ViewModel.Accounts;
using CsHealthcare.ViewModel.Cabin;
using CsHealthcare.ViewModel.Canteen;
using CsHealthcare.ViewModel.Diagnostic;
using CsHealthcare.ViewModel.Hospital;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.Master;
using CsHealthcare.ViewModel.MedicineCorner;
using CsHealthcare.ViewModel.Packages;
using CsHealthcare.ViewModel.Patient;
using CsHealthcare.ViewModel.Physiotherapy;
using CsHealthcare.ViewModel.Stock;
using CsHealthcare.ViewModel.Store;

namespace Cs.Utility
{
    public class SessionManager
    {
        public static string DashBoard
        {
            set { HttpContext.Current.Session["DashBoard"] = value; }
            get
            {
                if (HttpContext.Current.Session["DashBoard"] == null)
                {
                    return null;
                }
                else
                {
                    return (string)HttpContext.Current.Session["DashBoard"];
                }
            }
        }

        public static List<DrugSaleDetailsModel> DrugSaleDetails
        {
            set { HttpContext.Current.Session["DrugSaleDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["DrugSaleDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<DrugSaleDetailsModel>)HttpContext.Current.Session["DrugSaleDetails"];
                }
            }
        }


        public static List<SurgeonNameModel> SurgeonName
        {
            set { HttpContext.Current.Session["SurgeonName"] = value; }
            get
            {
                if (HttpContext.Current.Session["SurgeonName"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<SurgeonNameModel>)HttpContext.Current.Session["SurgeonName"];
                }
            }
        }
        public static List<AssistantDoctorModel> AssistantDoctor
        {
            set { HttpContext.Current.Session["AssistantDoctor"] = value; }
            get
            {
                if (HttpContext.Current.Session["AssistantDoctor"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<AssistantDoctorModel>)HttpContext.Current.Session["AssistantDoctor"];
                }
            }
        }
        public static List<AnesthesiaModel> Anesthesia
        {
            set { HttpContext.Current.Session["Anesthesia"] = value; }
            get
            {
                if (HttpContext.Current.Session["Anesthesia"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<AnesthesiaModel>)HttpContext.Current.Session["Anesthesia"];
                }
            }
        }
        public static List<PurposeOnOTModel> PurposeOnOT
        {
            set { HttpContext.Current.Session["PurposeOnOT"] = value; }
            get
            {
                if (HttpContext.Current.Session["PurposeOnOT"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PurposeOnOTModel>)HttpContext.Current.Session["PurposeOnOT"];
                }
            }
        }


        public static List<ICUBedsModel> ICUBeds
        {
            set { HttpContext.Current.Session["ICUBeds"] = value; }
            get
            {
                if (HttpContext.Current.Session["ICUBeds"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<ICUBedsModel>)HttpContext.Current.Session["ICUBeds"];
                }
            }
        }
        public static List<DrugDepartmentWiseStockOutDetailsModel> DrugDepartmentWiseStockOutDetails
        {
            set { HttpContext.Current.Session["DrugDepartmentWiseStockOutDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["DrugDepartmentWiseStockOutDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<DrugDepartmentWiseStockOutDetailsModel>)HttpContext.Current.Session["DrugDepartmentWiseStockOutDetails"];
                }
            }
        }

        public static List<OpdTherapyDetailsModel> OpdTherapyDetails
        {
            set { HttpContext.Current.Session["OpdTherapyDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["OpdTherapyDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<OpdTherapyDetailsModel>)HttpContext.Current.Session["OpdTherapyDetails"];
                }
            }
        }
        public static List<InPatientDrugSaleReturnDetailsModel> InPatientDrugSaleReturnDetails
        {
            set { HttpContext.Current.Session["InPatientDrugSaleReturnDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["InPatientDrugSaleReturnDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<InPatientDrugSaleReturnDetailsModel>)HttpContext.Current.Session["InPatientDrugSaleReturnDetails"];
                }
            }
        }

        public static List<PackageDetailsModel> PackageDetails
        {
            set { HttpContext.Current.Session["PackageDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["PackageDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PackageDetailsModel>)HttpContext.Current.Session["PackageDetails"];
                }
            }
        }
        public static List<BillingForCheckupPackageDetailsModel> BillingForCheckupPackageDetails
        {
            set { HttpContext.Current.Session["BillingForCheckupPackageDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["BillingForCheckupPackageDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<BillingForCheckupPackageDetailsModel>)HttpContext.Current.Session["BillingForCheckupPackageDetails"];
                }
            }
        }

        public static List<PackageForCheckupDetailsModel> PackageForCheckUpDetails
        {
            set { HttpContext.Current.Session["PackageForCheckUpDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["PackageForCheckUpDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PackageForCheckupDetailsModel>)HttpContext.Current.Session["PackageForCheckUpDetails"];
                }
            }
        }


        public static List<PackageExcludesModel> PackageExcludes
        {
            set { HttpContext.Current.Session["PackageExcludes"] = value; }
            get
            {
                if (HttpContext.Current.Session["PackageExcludes"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PackageExcludesModel>)HttpContext.Current.Session["PackageExcludes"];
                }
            }
        }

        public static List<DrugDepartmentWiseStockInDetailsModel> DrugDepartmentWiseStockInDetails
        {
            set { HttpContext.Current.Session["DrugDepartmentWiseStockInDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["DrugDepartmentWiseStockInDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<DrugDepartmentWiseStockInDetailsModel>)HttpContext.Current.Session["DrugDepartmentWiseStockInDetails"];
                }
            }
        }

        public static List<OptPatientBillDetailsModel> OptPatientBillDetails
        {
            set { HttpContext.Current.Session["OptPatientBillDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["OptPatientBillDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<OptPatientBillDetailsModel>)HttpContext.Current.Session["OptPatientBillDetails"];
                }
            }
        }





        public static List<InPatientTestdetailsModel> InPatientTestdetails
        {
            set { HttpContext.Current.Session["InPatientTestdetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["InPatientTestdetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<InPatientTestdetailsModel>)HttpContext.Current.Session["InPatientTestdetails"];
                }
            }
        }




        public static List<PatientAdmissionDetailsModel> PatientAdmissionDetails
        {
            set { HttpContext.Current.Session["PatientAdmissionDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientAdmissionDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientAdmissionDetailsModel>)HttpContext.Current.Session["PatientAdmissionDetails"];
                }
            }
        }


        public static List<InPatientDrugDetailsModel> InPatientDrugDetails
        {
            set { HttpContext.Current.Session["InPatientDrugDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["InPatientDrugDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<InPatientDrugDetailsModel>)HttpContext.Current.Session["InPatientDrugDetails"];
                }
            }
        }




        public static List<InPatientDailyBillDetailsModel> InPatientDailyBillDetails
        {
            set { HttpContext.Current.Session["InPatientDailyBillDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["InPatientDailyBillDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<InPatientDailyBillDetailsModel>)HttpContext.Current.Session["InPatientDailyBillDetails"];
                }
            }
        }
        public static List<PurchaseOrderDetailsModel> purchaseOrderModels1
        {
            set { HttpContext.Current.Session["purchaseOrderModels1"] = value; }
            get
            {
                if (HttpContext.Current.Session["purchaseOrderModels1"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PurchaseOrderDetailsModel>)HttpContext.Current.Session["purchaseOrderModels1"];
                }
            }
        }
        public static List<DrugStockDetailsModel> DrugStockDetails
        {
            set { HttpContext.Current.Session["DrugStockDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["DrugStockDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<DrugStockDetailsModel>)HttpContext.Current.Session["DrugStockDetails"];
                }
            }
        }

        public static List<PatientDetailsModel> PatientDetails
        {
            set { HttpContext.Current.Session["PatientDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientDetailsModel>)HttpContext.Current.Session["PatientDetails"];
                }
            }
        }

        public static List<CashItemModel> CashItems
        {
            set { HttpContext.Current.Session["CashItems"] = value; }
            get
            {
                if (HttpContext.Current.Session["CashItems"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<CashItemModel>)HttpContext.Current.Session["CashItems"];
                }
            }
        }

        public static List<StockInDetailsModel> StockInDetails
        {
            set { HttpContext.Current.Session["StockInDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["StockInDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<StockInDetailsModel>)HttpContext.Current.Session["StockInDetails"];
                }
            }
        }

        public static List<StockOutDetailsModel> StockOutDetails
        {
            set { HttpContext.Current.Session["StockOutDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["StockOutDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<StockOutDetailsModel>)HttpContext.Current.Session["StockOutDetails"];
                }
            }
        }
        public static List<InsurancePlanModel> Insurance
        {
            set { HttpContext.Current.Session["Insurance"] = value; }
            get
            {
                if (HttpContext.Current.Session["Insurance"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<InsurancePlanModel>)HttpContext.Current.Session["Insurance"];
                }
            }
        }

        public static List<EducationModel> Education
        {
            set { HttpContext.Current.Session["Education"] = value; }
            get
            {
                if (HttpContext.Current.Session["Education"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<EducationModel>)HttpContext.Current.Session["Education"];
                }
            }
        }
        public static List<BedModel> Bed
        {
            set { HttpContext.Current.Session["Bed"] = value; }
            get
            {
                if (HttpContext.Current.Session["Bed"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<BedModel>)HttpContext.Current.Session["Bed"];
                }
            }
        }
        public static List<PatientChiefComplaintModel> PatientChiefComplaint
        {
            set { HttpContext.Current.Session["PatientChiefComplaint"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientChiefComplaint"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientChiefComplaintModel>)HttpContext.Current.Session["PatientChiefComplaint"];
                }
            }
        }

        public static PatientGeneralExamModel PatientGeneralExam
        {
            set { HttpContext.Current.Session["PatientGeneralExam"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientGeneralExam"] == null)
                {
                    return null;
                }
                else
                {
                    return (PatientGeneralExamModel)HttpContext.Current.Session["PatientGeneralExam"];
                }
            }
        }

        public static List<PatientPastIllnessModel> PatientPastIllness
        {
            set { HttpContext.Current.Session["PatientPastIllness"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientPastIllness"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientPastIllnessModel>)HttpContext.Current.Session["PatientPastIllness"];
                }
            }
        }

        public static List<PatientPastHistoryOfMadicationModel> PatientPastHistoryOfMadication
        {
            set { HttpContext.Current.Session["PatientPastHistoryOfMadication"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientPastHistoryOfMadication"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientPastHistoryOfMadicationModel>)HttpContext.Current.Session["PatientPastHistoryOfMadication"];
                }
            }
        }

        public static List<PatientFamilyDiseaseModel> PatientFamilyDisease
        {
            set { HttpContext.Current.Session["PatientFamilyDisease"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientFamilyDisease"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientFamilyDiseaseModel>)HttpContext.Current.Session["PatientFamilyDisease"];
                }
            }
        }

        public static List<PatientAllergyInformationModel> PatientAllergyInformation
        {
            set { HttpContext.Current.Session["PatientAllergyInformation"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientAllergyInformation"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientAllergyInformationModel>)HttpContext.Current.Session["PatientAllergyInformation"];
                }
            }
        }

        public static PatientPersonalHistoryModel PatientPersonalHistory
        {
            set { HttpContext.Current.Session["PatientPersonalHistory"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientPersonalHistory"] == null)
                {
                    return null;
                }
                else
                {
                    return (PatientPersonalHistoryModel)HttpContext.Current.Session["PatientPersonalHistory"];
                }
            }
        }

        public static List<PatientPersonalHistoryDetailsModel> PatientPersonalHistoryDetails
        {
            set { HttpContext.Current.Session["PatientPersonalHistoryDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientPersonalHistoryDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientPersonalHistoryDetailsModel>)HttpContext.Current.Session["PatientPersonalHistoryDetails"];
                }
            }
        }

        public static List<PatientTreatmentModel> PatientTreatment
        {
            set { HttpContext.Current.Session["PatientTreatment"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientTreatment"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientTreatmentModel>)HttpContext.Current.Session["PatientTreatment"];
                }
            }
        }

        public static List<PatientInvestigationModel> PatientInvestigation
        {
            set { HttpContext.Current.Session["PatientInvestigation"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientInvestigation"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientInvestigationModel>)HttpContext.Current.Session["PatientInvestigation"];
                }
            }
        }

        public static List<PatientInvestigationModel> PatientPreviousInvestigation
        {
            set { HttpContext.Current.Session["PatientPreviousInvestigation"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientPreviousInvestigation"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientInvestigationModel>)HttpContext.Current.Session["PatientPreviousInvestigation"];
                }
            }
        }

        public static List<PatientSpecialNoteModel> PatientSpecialNote
        {
            set { HttpContext.Current.Session["PatientSpecialNote"] = value; }
            get
            {
                if (HttpContext.Current.Session["PatientSpecialNote"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PatientSpecialNoteModel>)HttpContext.Current.Session["PatientSpecialNote"];
                }
            }
        }

        public static List<TestRequestModel> TestRequest
        {
            set { HttpContext.Current.Session["TestRequest"] = value; }
            get
            {
                if (HttpContext.Current.Session["TestRequest"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<TestRequestModel>)HttpContext.Current.Session["TestRequest"];
                }
            }
        }

        public static int PresentationType
        {
            set { HttpContext.Current.Session["PresentationType"] = value; }
            get
            {
                if (HttpContext.Current.Session["PresentationType"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)HttpContext.Current.Session["PresentationType"];
                }
            }
        }

        public static string DrugGroup
        {
            set { HttpContext.Current.Session["DrugGroup"] = value; }
            get
            {
                if (HttpContext.Current.Session["DrugGroup"] == null)
                {
                    return "";
                }
                else
                {
                    return (string)HttpContext.Current.Session["DrugGroup"];
                }
            }
        }

        public static int Manufacturer
        {
            set { HttpContext.Current.Session["Manufacturer"] = value; }
            get
            {
                if (HttpContext.Current.Session["Manufacturer"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)HttpContext.Current.Session["Manufacturer"];
                }
            }
        }

        public static int Drug
        {
            set { HttpContext.Current.Session["Drug"] = value; }
            get
            {
                if (HttpContext.Current.Session["Drug"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)HttpContext.Current.Session["Drug"];
                }
            }
        }

        public static string GenericName
        {
            set { HttpContext.Current.Session["GenericName"] = value; }
            get
            {
                if (HttpContext.Current.Session["GenericName"] == null)
                {
                    return "";
                }
                else
                {
                    return (string)HttpContext.Current.Session["GenericName"];
                }
            }
        }

        public static int Allergy
        {
            set { HttpContext.Current.Session["Allergy"] = value; }
            get
            {
                if (HttpContext.Current.Session["Allergy"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)HttpContext.Current.Session["Allergy"];
                }
            }
        }

        public static List<DrugGroupModel> DrugsGroup
        {
            set { HttpContext.Current.Session["DrugsGroup"] = value; }
            get
            {
                if (HttpContext.Current.Session["DrugsGroup"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<DrugGroupModel>)HttpContext.Current.Session["DrugsGroup"];
                }
            }
        }

        public static List<DrugPresentationTypeModel> DrugTypesList
        {
            set { HttpContext.Current.Session["DrugTypesList"] = value; }
            get
            {
                if (HttpContext.Current.Session["DrugTypesList"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<DrugPresentationTypeModel>)HttpContext.Current.Session["DrugTypesList"];
                }
            }
        }

        public static List<PharmacyRequisitionDetailsModel> PharmacyRequisitionDetails
        {
            set { HttpContext.Current.Session["PharmacyRequisitionDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["PharmacyRequisitionDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<PharmacyRequisitionDetailsModel>)HttpContext.Current.Session["PharmacyRequisitionDetails"];
                }
            }
        }


        public static List<ItemStockOutDetailsModel> ItemStockOutDetails
        {
            set { HttpContext.Current.Session["ItemStockOutDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["ItemStockOutDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<ItemStockOutDetailsModel>)HttpContext.Current.Session["ItemStockOutDetails"];
                }
            }
        }
        public static List<StoreRequisitionDetailsModel> StoreRequisitionDetails
        {
            set { HttpContext.Current.Session["StoreRequisitionDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["StoreRequisitionDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<StoreRequisitionDetailsModel>)HttpContext.Current.Session["StoreRequisitionDetails"];
                }
            }
        }

        public static List<SellsDetailsModel> SellsDetails
        {
            set { HttpContext.Current.Session["SellsDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["SellsDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<SellsDetailsModel>)HttpContext.Current.Session["SellsDetails"];
                }
            }
        }
        public static List<CanteenFoodInPatientDetailsModel> CanteenFoodInPatientDetails
        {
            set { HttpContext.Current.Session["CanteenFoodInPatientDetails"] = value; }
            get
            {
                if (HttpContext.Current.Session["CanteenFoodInPatientDetails"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<CanteenFoodInPatientDetailsModel>)HttpContext.Current.Session["CanteenFoodInPatientDetails"];
                }
            }
        }


    }
}
