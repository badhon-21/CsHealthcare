using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Doctor;
using CsHealthcare.DataAccess.Entities.Hospital;
using CsHealthcare.DataAccess.Entities.Operation;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity;
using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Entity.Cabin;
using CsHealthcare.DataAccess.Entity.Canteen;
using CsHealthcare.DataAccess.Entity.Diagnostic;
using CsHealthcare.DataAccess.Entity.EmployeeLoan;
using CsHealthcare.DataAccess.Entity.Hospital;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.LabItem;
using CsHealthcare.DataAccess.Entity.LeaveManagement;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Entity.MicrobiologyTest;
using CsHealthcare.DataAccess.Entity.Packages;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Entity.Physiotherapy;
using CsHealthcare.DataAccess.Entity.Stock;
using CsHealthcare.DataAccess.Entity.Store;
using CsHealthcare.ViewModel;
using CsHealthcare.DataAccess.HumanResource;
using CsHealthcare.ViewModel.Accounts;
using CsHealthcare.ViewModel.Cabin;
using CsHealthcare.ViewModel.Canteen;
using CsHealthcare.ViewModel.Diagnostic;
using CsHealthcare.ViewModel.Disease;
using CsHealthcare.ViewModel.Doctor;
using CsHealthcare.ViewModel.EmployeeLoan;
using CsHealthcare.ViewModel.Hospital;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.LabItem;
using CsHealthcare.ViewModel.LeaveManagement;
using CsHealthcare.ViewModel.Master;
using CsHealthcare.ViewModel.MedicineCorner;
using CsHealthcare.ViewModel.MicrobiologyTest;
using CsHealthcare.ViewModel.Operation;
using CsHealthcare.ViewModel.Packages;
using CsHealthcare.ViewModel.Patient;
using CsHealthcare.ViewModel.Physiotherapy;
using CsHealthcare.ViewModel.Stock;
using CsHealthcare.ViewModel.Store;
using CsHealthcare.ViewModel.User;

namespace CsHealthcare.DataAccess.Modelfactory
{
    public interface IModelfactory
    {
        DEPARTMENT Create(DepartmentModel obj);
        DepartmentModel Create(DEPARTMENT obj);
        DrugModel Create(DRUG obj);
        DRUG Create(DrugModel obj);
        DRUG_MANUFACTURER Create(DrugMenufacturerModel obj);
        DrugMenufacturerModel Create(DRUG_MANUFACTURER obj);
        DURG_PRESENTATION_TYPE Create(DrugPresentationTypeModel obj);
        DrugPresentationTypeModel Create(DURG_PRESENTATION_TYPE obj);
        DrugGroup Create(DrugGroupModel obj);
        DrugGroupModel Create(DrugGroup obj);
        DrugDose Create(DrugDoseModel obj);
        DrugDoseModel Create(DrugDose obj);


        GL_ACCOUNT Create(GL_ACCOUNTModel obj);
        GL_ACCOUNTModel Create(GL_ACCOUNT obj);
        BankAccount Create(BankAccountModel obj);
        BankAccountModel Create(BankAccount obj);
        BankTransaction Create(BankTransactionModel obj);
        BankTransactionModel Create(BankTransaction obj);
        EmployeeDesignation Create(EmployeeDesignationModel obj);
        EmployeeDesignationModel Create(EmployeeDesignation obj);
        EmployeeInfo Create(EmployeeInfoModel obj);
        EmployeeInfoModel Create(EmployeeInfo obj);

        TEST_CATEGORY Create(TestCategoryModel obj);
        TestCategoryModel Create(TEST_CATEGORY obj);

        Test_Name Create(TestNameModel obj);
        TestNameModel Create(Test_Name obj);
        Supplier Create(SupplierModel obj);
        SupplierModel Create(Supplier obj);

        LeaveType Create(LeaveTypeModel obj);
        LeaveTypeModel Create(LeaveType obj);
        LeavePlan Create(LeavePlanModel obj);
        LeavePlanModel Create(LeavePlan obj);
        LeaveOfAbsenceMaster Create(LeaveOfAbsenceMasterModel obj);
        LeaveOfAbsenceMasterModel Create(LeaveOfAbsenceMaster obj);
        LeaveOfAbsenceDetails Create(LeaveOfAbsenceDetailsModel obj);
        LeaveOfAbsenceDetailsModel Create(LeaveOfAbsenceDetails obj);


        SupplierPayment Create(SupplierPaymentModel obj);
        SupplierPaymentModel Create(SupplierPayment obj);

        LeavePlanRate Create(LeavePlanRateModel obj);
        LeavePlanRateModel Create(LeavePlanRate obj);
        PatientInformation Create(PatientInformationModel obj);
        PatientInformationModel Create(PatientInformation obj);
        Patient Create(PatientModel obj);
        PatientModel Create(Patient obj);
        PatientEducation Create(PatientEducationModel obj);
        PatientEducationModel Create(PatientEducation obj);

        PatientDetails Create(PatientDetailsModel obj);
        PatientDetailsModel Create(PatientDetails obj);



        OccurrenceType Create(OccurrenceTypeModel obj);
        OccurrenceTypeModel Create(OccurrenceType obj);
        Occurrence Create(OccurrenceModel obj);
        OccurrenceModel Create(Occurrence obj);
        StockIn Create(StockInModel obj);
       StockInModel Create(StockIn obj);
        StockOutItem Create(StockOutItemModel obj);
        StockOutItemModel Create(StockOutItem obj);
        StockOutDetails Create(StockOutDetailsModel obj);
        StockOutDetailsModel Create(StockOutDetails obj);
        PharmacyRequisitionDetails Create(PharmacyRequisitionDetailsModel obj);
        PharmacyRequisitionDetailsModel Create(PharmacyRequisitionDetails obj);

        PharmacyRequisition Create(PharmacyRequisitionModel obj);
        PharmacyRequisitionModel Create(PharmacyRequisition obj);

        DrugStockIn Create(DrugStockInModel obj);
        DrugStockInModel Create(DrugStockIn obj);
        DrugStockDetails Create(DrugStockDetailsModel obj);
        DrugStockDetailsModel Create(DrugStockDetails obj);

        DrugDepartmentWiseStockInModel Create(DrugDepartmentWiseStockIn obj);
        DrugDepartmentWiseStockIn Create(DrugDepartmentWiseStockInModel obj);

        TaxConfiguration Create(TaxConfigurationModel obj);
        TaxConfigurationModel Create(TaxConfiguration obj);

        LoanConfig Create(LoanConfigModel obj);
        LoanConfigModel Create(LoanConfig obj);

        loanConfigPlan Create(LoanConfigPlanModel obj);
        LoanConfigPlanModel Create(loanConfigPlan obj);
       
        Holiday Create(HolidayModel obj);
        HolidayModel Create(Holiday obj);
        ShiftInfo Create(ShiftInfoModel obj);
        ShiftInfoModel Create(ShiftInfo obj);
        AllergyInformation Create(AllergyInformationModel obj);

        AllergyInformationModel Create(AllergyInformation obj);

        AllergySubstance Create(AllergySubstanceModel obj);
        AllergySubstanceModel Create(AllergySubstance obj);
        DoctorAppointment Create(DoctorAppointmentModel obj);
        DoctorAppointmentModel Create(DoctorAppointment obj);

        DoctorAppointmentPayment Create(DoctorAppointmentPaymentModel obj);

        DoctorAppointmentPaymentModel Create(DoctorAppointmentPayment obj);

        DoctorBusinessHoliday Create(DoctorBusinessHolidayModel obj);
        DoctorBusinessHolidayModel Create(DoctorBusinessHoliday obj);

        DoctorBusinessHour Create(DoctorBusinessHourModel obj);
        DoctorBusinessHourModel Create(DoctorBusinessHour obj);
        DoctorInformationModel Create(DoctorInformation obj);

        DoctorInformation Create(DoctorInformationModel obj);

        DoctorNote Create(DoctorNoteModel obj);
        DoctorNoteModel Create(DoctorNote obj);

        VisitDiscountModel Create(VisitDiscount obj);

        VisitDiscount Create(VisitDiscountModel obj);
        HospitalInformation Create(HospitalInformationModel obj);
        HospitalInformationModel Create(HospitalInformation obj);

        Disease Create(DiseaseModel obj);

        DiseaseModel Create(Disease obj);

        Education Create(EducationModel obj);
        EducationModel Create(Education obj);
        FamilyTreeModel Create(FamilyTree obj);
        FamilyTree Create(FamilyTreeModel obj);
        MsAmountPurpose Create(MsAmountPurposeModel obj);
        MsAmountPurposeModel Create(MsAmountPurpose obj);
        Occupation Create(OccupationModel obj);
        OccupationModel Create(Occupation obj);

        SocialEconomicStatus Create(SocialEconomicStatusModel obj);

        SocialEconomicStatusModel Create(SocialEconomicStatus obj);
        SpecialNote Create(SpecialNoteModel obj);

        SpecialNoteModel Create(SpecialNote obj);
        DrugDoseChart Create(DrugDoseChartModel obj);

        DrugDoseChartModel Create(DrugDoseChart obj);

        DrugDuration Create(DrugDurationModel obj);
        DrugDurationModel Create(DrugDuration obj);

        DrugInvoicePayment Create(DrugInvoicePaymentModel obj);
        DrugInvoicePaymentModel Create(DrugInvoicePayment obj);
        DrugSaleReturn Create(DrugSaleReturnModel obj);
        DrugSaleReturnModel Create(DrugSaleReturn obj);

        DrugsSelectedGroups Create(DrugsSelectedGroupsModel obj);

        DrugsSelectedGroupsModel Create(DrugsSelectedGroups obj);
        OperationNote Create(OperationNoteModel obj);
        OperationNoteModel Create(OperationNote obj);
        ChiefComplaint Create(ChiefComplaintModel obj);
        ChiefComplaintModel Create(ChiefComplaint obj);


        ChiefComplaintDuration Create(ChiefComplaintDurationModel obj);
        ChiefComplaintDurationModel Create(ChiefComplaintDuration obj);
        PatientAllergyInformation Create(PatientAllergyInformationModel obj);
        PatientAllergyInformationModel Create(PatientAllergyInformation obj);
        PatientChiefComplaint Create(PatientChiefComplaintModel obj);

        PatientChiefComplaintModel Create(PatientChiefComplaint obj);

        PatientEnroll Create(PatientEnrollModel obj);
        PatientEnrollModel Create(PatientEnroll obj);

        PatientFamilyDisease Create(PatientFamilyDiseaseModel obj);
        PatientFamilyDiseaseModel Create(PatientFamilyDisease obj);

        PatientGeneralExam Create(PatientGeneralExamModel obj);
        PatientGeneralExamModel Create(PatientGeneralExam obj);
        PatientHistory Create(PatientHistoryModel obj);

        PatientHistoryModel Create(PatientHistory obj);

        PatientInvestigation Create(PatientInvestigationModel obj);

        PatientInvestigationModel Create(PatientInvestigation obj);

        PatientOldInvestigation Create(PatientOldInvestigationModel obj);

        PatientOldInvestigationModel Create(PatientOldInvestigation obj);
        PatientPastHistoryOfMadication Create(PatientPastHistoryOfMadicationModel obj);

        PatientPastHistoryOfMadicationModel Create(PatientPastHistoryOfMadication obj);

        PatientPastIllness Create(PatientPastIllnessModel obj);
        PatientPastIllnessModel Create(PatientPastIllness obj);
        PatientPersonalAttribute Create(PatientPersonalAttributeModel obj);
        PatientPersonalAttributeModel Create(PatientPersonalAttribute obj);
        PatientPersonalHistory Create(PatientPersonalHistoryModel obj);
        PatientPersonalHistoryModel Create(PatientPersonalHistory obj);
        PatientPersonalHistoryDetails Create(PatientPersonalHistoryDetailsModel obj);
        PatientPersonalHistoryDetailsModel Create(PatientPersonalHistoryDetails obj);

        PatientPrescription Create(PatientPrescriptionModel obj);
        PatientPrescriptionModel Create(PatientPrescription obj);
        PatientSpecialNote Create(PatientSpecialNoteModel obj);
        PatientSpecialNoteModel Create(PatientSpecialNote obj);

        PatientTreatment Create(PatientTreatmentModel obj);
        PatientTreatmentModel Create(PatientTreatment obj);

        ReportScanCopy Create(ReportScanCopyModel obj);
        ReportScanCopyModel Create(ReportScanCopy obj);

        AppAppointmentSystemUser Create(AppAppointmentSystemUserModel obj);
        AppAppointmentSystemUserModel Create(AppAppointmentSystemUser obj);
        AppMedicineCornerUser Create(AppMedicineCornerUserModel obj);
        AppMedicineCornerUserModel Create(AppMedicineCornerUser obj);
        AppPatientManagementUser Create(AppPatientManagementUserModel obj);

        AppPatientManagementUserModel Create(AppPatientManagementUser obj);
        AppUser Create(AppUserModel obj);


        AppUserModel Create(AppUser obj);

        DrugSaleDetails Create(DrugSaleDetailsModel obj);
        DrugSaleDetailsModel Create(DrugSaleDetails obj);


        InsuranceCompanyModel Create(InsuranceCompany obj);

        InsuranceCompany Create(InsuranceCompanyModel obj);


        InsurancePlanModel Create(InsurancePlan obj);

        InsurancePlan Create(InsurancePlanModel obj);


       DrugSaleHistoryModel Create(DrugSaleHistory obj);

        DrugSaleHistory Create(DrugSaleHistoryModel obj);


        DrugSaleDetailsHistoryModel Create(DrugSaleDetailsHistory obj);

        DrugSaleDetailsHistory Create(DrugSaleDetailsHistoryModel obj);
        LC Create(LcModel obj);
        LcModel Create(LC obj);

        Cabin Create(CabinModel obj);
        CabinModel Create(Cabin obj);
        CabinType Create(CabinTypeModel obj);
        CabinTypeModel Create(CabinType obj);

        CabinRent Create(CabinRentModel obj);
        CabinRentModel Create(CabinRent obj);

        CabinAmenity Create(CabinAmenityModel obj);
        CabinAmenityModel Create(CabinAmenity obj);


        TestRequest Create(TestRequestModel obj);
        TestRequestModel Create(TestRequest obj);


        OperationTypeModel Create(OperationType obj);

        OperationType Create(OperationTypeModel obj);
        WardModel Create(Ward obj);

        Ward Create(WardModel obj);

        WardTypeModel Create(WardType obj);

        WardType Create(WardTypeModel obj);

        LabItemModel Create(LabItem obj);

        LabItem Create(LabItemModel obj);

        Specimen Create(SpecimenModel obj);
        SpecimenModel Create(Specimen obj);


        MicrobiologyTest Create(MicrobiologyTestModel obj);
        MicrobiologyTestModel Create(MicrobiologyTest obj);
        StoreItem Create(StoreItemModel obj);
        StoreItemModel Create(StoreItem obj);
        PurchaseOrder Create(PurchaseOrderModel obj);
        PurchaseOrderModel Create(PurchaseOrder obj);
        PurchaseOrderDetails Create(PurchaseOrderDetailsModel obj);
        PurchaseOrderDetailsModel Create(PurchaseOrderDetails obj);

        Purpose Create(PurposeModel obj);
        PurposeModel Create(Purpose obj);
        PatientAdmission Create(PatientAdmissionModel obj);
        PatientAdmissionModel Create(PatientAdmission obj);
        PatientAdmissionDetails Create(PatientAdmissionDetailsModel obj);
        PatientAdmissionDetailsModel Create(PatientAdmissionDetails obj);


        PatientLaser Create(PatientLaserModel obj);
        PatientLaserModel Create(PatientLaser obj);

        InPatientDailyBill Create(InPatientDailyBillModel obj);
        InPatientDailyBillModel Create(InPatientDailyBill obj);
        InPatientDailyBillDetails Create(InPatientDailyBillDetailsModel obj);
        InPatientDailyBillDetailsModel Create(InPatientDailyBillDetails obj);

        InPatientDrug Create(InPatientDrugModel obj);
        InPatientDrugModel Create(InPatientDrug obj);

        InPatientDrugDetails Create(InPatientDrugDetailsModel obj);
        InPatientDrugDetailsModel Create(InPatientDrugDetails obj);


        InPatientDischarge Create(InPatientDischargeModel obj);
        InPatientDischargeModel Create(InPatientDischarge obj);

        InPatientDoctorInvoice Create(InPatientDoctorInvoiceModel obj);
        InPatientDoctorInvoiceModel Create(InPatientDoctorInvoice obj);



        InPatientTest Create(InPatientTestModel obj);
        InPatientTestModel Create(InPatientTest obj);
        InPatientTestdetails Create(InPatientTestdetailsModel obj);
        InPatientTestdetailsModel Create(InPatientTestdetails obj);


        OptPatientBill Create(OptPatientBillModel obj);
        OptPatientBillModel Create(OptPatientBill obj);
        OptPatientBillDetails Create(OptPatientBillDetailsModel obj);
        OptPatientBillDetailsModel Create(OptPatientBillDetails obj);

        Customer Create(CustomerModel obj);
        CustomerModel Create(Customer obj);
        Product Create(ProductModel obj);
        ProductModel Create(Product obj);

        Category Create(CategoryModel obj);
        CategoryModel Create(Category obj);
        Sells Create(SellsModel obj);
        SellsModel Create(Sells obj);

        SellsDetails Create(SellsDetailsModel obj);
        SellsDetailsModel Create(SellsDetails obj);

        Package Create(PackageModel obj);
        PackageModel Create(Package obj);

        PackageDetails Create(PackageDetailsModel obj);
        PackageDetailsModel Create(PackageDetails obj);

        PackageExcludes Create(PackageExcludesModel obj);
        PackageExcludesModel Create(PackageExcludes obj);

        InPatientDrugSaleReturn Create(InPatientDrugSaleReturnModel obj);
        InPatientDrugSaleReturnModel Create(InPatientDrugSaleReturn obj);

        InPatientDrugSaleReturnDetails Create(InPatientDrugSaleReturnDetailsModel obj);
        InPatientDrugSaleReturnDetailsModel Create(InPatientDrugSaleReturnDetails obj);
        DrugDepartmentWiseStockOut Create(DrugDepartmentWiseStockOutModel obj);
        DrugDepartmentWiseStockOutModel Create(DrugDepartmentWiseStockOut obj);
        DrugDepartmentWiseStockOutDetails Create(DrugDepartmentWiseStockOutDetailsModel obj);
        DrugDepartmentWiseStockOutDetailsModel Create(DrugDepartmentWiseStockOutDetails obj);





        Physiotherapy Create(PhysiotherapyModel obj);
        PhysiotherapyModel Create(Physiotherapy obj);


        OPDTherapy Create(OPDTherapyModel obj);
        OPDTherapyModel Create(OPDTherapy obj);
        OpdTherapyDetails Create(OpdTherapyDetailsModel obj);
        OpdTherapyDetailsModel Create(OpdTherapyDetails obj);

        OpdTherapyDueCollection Create(OpdTherapyDueCollectionModel obj);
        OpdTherapyDueCollectionModel Create(OpdTherapyDueCollection obj);
        ICU Create(ICUModel obj);
        ICUModel Create(ICU obj);
        ICUBeds Create(ICUBedsModel obj);
        ICUBedsModel Create(ICUBeds obj);
        ICURent Create(ICURentModel obj);
        ICURentModel Create(ICURent obj);

        InPatientTransfer Create(InPatientTransferModel obj);
        InPatientTransferModel Create(InPatientTransfer obj);
        InPatientTransferBack Create(InPatientTransferBackModel obj);
        InPatientTransferBackModel Create(InPatientTransferBack obj);


        InPatientDischargeSummaryModel Create(InPatientDischargeSummary obj);
        InPatientDischargeSummary Create(InPatientDischargeSummaryModel obj);

        PrescriptionAttatchment Create(PrescriptionAttatchmentModel obj);
        PrescriptionAttatchmentModel Create(PrescriptionAttatchment obj);

        PatientTestReportAttatchment Create(PatientTestReportAttatchmentModel obj);
        PatientTestReportAttatchmentModel Create(PatientTestReportAttatchment obj);

        SurgeonName Create(SurgeonNameModel obj);
        SurgeonNameModel Create(SurgeonName obj);

        PurposeOnOT Create(PurposeOnOTModel obj);
        PurposeOnOTModel Create(PurposeOnOT obj);

        OperationTheatre Create(OperationTheatreModel obj);
        OperationTheatreModel Create(OperationTheatre obj);


        Anesthesia Create(AnesthesiaModel obj);
        AnesthesiaModel Create(Anesthesia obj);

        AssistantDoctor Create(AssistantDoctorModel obj);
        AssistantDoctorModel Create(AssistantDoctor obj);


        SEROLOGY Create(SEROLOGYModel Obj);
        SEROLOGYModel Create(SEROLOGY Obj);

        IMMUNOLOGICAL Create(IMMUNOLOGICALModel obj);
        IMMUNOLOGICALModel Create(IMMUNOLOGICAL obj);

        ENDOCRINOLOGY Create(ENDOCRINOLOGYModel obj);
        ENDOCRINOLOGYModel Create(ENDOCRINOLOGY obj);
        BioChemistry Create(BioChemistryModel obj);
        BioChemistryModel Create(BioChemistry obj);
        PatientCard Create(PatientCardModel obj);
        PatientCardModel Create(PatientCard obj);

        PatientDueCollection Create(PatientDueCollectionModel obj);
        PatientDueCollectionModel Create(PatientDueCollection obj);


        CabinToCabinTransfer Create(CabinToCabinTransferModel obj);
        CabinToCabinTransferModel Create(CabinToCabinTransfer obj);


        CabinTransferBack Create(CabinTransferBackModel obj);
        CabinTransferBackModel Create(CabinTransferBack obj);


        InPatientDischargeDueCollection Create(InPatientDischargeDueCollectionModel obj);
        InPatientDischargeDueCollectionModel Create(InPatientDischargeDueCollection obj);
    }
}
