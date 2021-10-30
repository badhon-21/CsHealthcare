using System;
using CsHealthcare.DataAccess;
using CsHealthcare.DataAccess.Dialysis;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Doctor;
using CsHealthcare.DataAccess.Entities.Hospital;
using CsHealthcare.DataAccess.Entities.Operation;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity;
using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Entity.Ambulance;
using CsHealthcare.DataAccess.Entity.Cabin;
using CsHealthcare.DataAccess.Entity.Canteen;
using CsHealthcare.DataAccess.Entity.Diagnostic;
using CsHealthcare.DataAccess.Entity.EmployeeLoan;
using CsHealthcare.DataAccess.Entity.Hospital;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.LabItem;
using CsHealthcare.DataAccess.Entity.LeaveManagement;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.HumanResource;
using CsHealthcare.Repositories;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Entity.MicrobiologyTest;
using CsHealthcare.DataAccess.Entity.Packages;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Entity.Physiotherapy;
using CsHealthcare.DataAccess.Entity.Stock;
using CsHealthcare.DataAccess.Entity.Store;
using CsHealthcare.DataAccess.Entity.Views;
using CsHealthcare.Services.Interface;

namespace CsHealthcare.Services
{
    public class AppServices : IService, IDisposable
    {
        private Repository<CheckInCheckOut> _CheckInCheckOutRepository;

        private Repository<PatientEnrollDialysis> _patientEnrollDialysis;
        private Repository<MsDialysisAmountPurpose> _msDialysisAmountPurpose;
        private Repository<DialysisPayment> _dialysisPayment;
        private Repository<PatientDialysis> _patientDialysis;

        private readonly AppDbContext _context = new AppDbContext();
        private Repository<DEPARTMENT> _departmentRepository;
        private Repository<GL_ACCOUNT> _glAccountRepository;
        private Repository<BankAccount> _bankAccountRepository;
        private Repository<BankTransaction> _bankTransactionRepository;
        private Repository<DailyExpense> _dailyExpenseRepository;
        private Repository<EmployeeDesignation> _employeeDesignationRepository;
        private Repository<EmployeeInfo> _employeeInfoRepository;
        private Repository<EmployeeAttendenceCheckInOut> _employeeAttendanceRepository;

        private Repository<DRUG> _drugRepository;

        private Repository<DRUG_MANUFACTURER> _drugMenufacturerRepository;
        private Repository<DURG_PRESENTATION_TYPE> _drugPresentationtypeRepository;
        private Repository<DrugDose> _drugDoseRepository;
        private Repository<DrugGroup> _drugGroupRepository;

        private Repository<DrugStockIn> _drugStockInRepository;
        private Repository<DrugStockDetails> _drugStockDetailsRepository;
        private Repository<DrugSale> _drugSaleRepository;
        private Repository<DrugSaleDetails> _drugSaleDetailsRepository;

        private Repository<DrugSaleHistory> _drugSaleHistoryRepository;
        private Repository<DrugSaleDetailsHistory> _drugSaleDetailsHistoryRepository;


        private Repository<TEST_CATEGORY> _testCategoryRepository;
        private Repository<Test_Name> _testNameRepository;
        private Repository<Supplier> _supplierRepository;



        private Repository<LeaveType> _leaveTypeRepository;
        private Repository<LeavePlan> _leavePlanRepository;
        private Repository<LeavePlanRate> _leavePlanRateRepository;
        private Repository<LeaveOfAbsenceMaster> _leaveOfAbsenceMaster;
        private Repository<LeaveOfAbsenceDetails> _leaveOfAbsenceDetails;
        //private Repository<EmployeeInfo> _employeeInfoRepository;


        private Repository<SupplierPayment> _supplierPaymentRepository;
        private Repository<Patient> _patientRepository;
        private Repository<PatientEducation> _patientEducationRepository;
        private Repository<PatientDetails> _patientDetailsRepository;
        private Repository<OccurrenceType> _occurrenceTypeRepository;
        private Repository<Occurrence> _occurrenceRepository;

        private Repository<TaxConfiguration> _taxConfigurationRepository;
        private Repository<LoanConfig> _loanConfigRepository;
        private Repository<loanConfigPlan> _loanConfigPlanRepository;
        private Repository<ShiftInfo> _shiftInfoRepository;


        private Repository<Holiday> _holidayRepository;

        private Repository<AllergyInformation> _allergyInformationRepository;
        private Repository<AllergySubstance> _allergySubstanceRepository;
        private Repository<DoctorAppointment> _doctorAppointmentRepository;
        private Repository<DoctorAppointmentPayment> _doctorAppointmentPaymentRepository;
        private Repository<DoctorBusinessHoliday> _doctorBusinessHolidayRepository;

        private Repository<DoctorInformation> _doctorInformationRepository;

        private Repository<DoctorNote> _doctorNoteRepository;
        private Repository<VisitDiscount> _visitDiscountRepository;
        private Repository<HospitalInformation> _hospitalInformationRepository;
        private Repository<Disease> _diseaseRepository;

        private Repository<DiseaseCondition> _diseaseConditionRepository;

        private Repository<Education> _educationRepository;
        private Repository<FamilyTree> _familyTreeRepository;
        private Repository<MsAmountPurpose> _msAmountPurposeRepository;
        private Repository<Occupation> _occupationRepository;
        private Repository<SocialEconomicStatus> _socialEconomicStatusRepository;
        private Repository<SpecialNote> _specialNoteRepository;
        private Repository<OperationNote> _operationNoteRepository;
        private Repository<DrugDailyStockHistory> _drugDailyStockHistoryRepository;
        private Repository<DrugDoseChart> _drugDoseChartRepository;
        private Repository<DrugDuration> _drugDurationRepository;
        private Repository<DrugInvoicePayment> _drugInvoicePaymentRepository;
        private Repository<DrugSaleReturn> _drugSaleReturnRepository;
        private Repository<DrugsSelectedGroups> _drugsSelectedGroupsRepository;
        private Repository<ChiefComplaint> _chiefComplaintRepository;
        private Repository<ChiefComplaintDuration> _chiefComplaintDurationRepository;

        private Repository<PatientAllergyInformation> _patientAllergyInformationRepository;
        private Repository<PatientChiefComplaint> _patientChiefComplaintRepository;

        private Repository<PatientEnroll> _patientEnrollRepository;

        private Repository<PatientFamilyDisease> _patientFamilyDiseaseRepository;

        private Repository<PatientGeneralExam> _patientGeneralExamRepository;

        private Repository<PatientHistory> _patientHistoryExamRepository;
        private Repository<PatientInformation> _patientInformationRepository;
        private Repository<PatientInvestigation> _patientInvestigationRepository;
        private Repository<PatientOldInvestigation> _patientOldInvestigationRepository;

        private Repository<PatientPastHistoryOfMadication> _patientPastHistoryOfMadicationRepository;
        private Repository<PatientPastIllness> _patientPastIllnessRepository;
        private Repository<PatientPersonalAttribute> _patientPersonalAttributeRepository;
        private Repository<PatientPersonalHistory> _patientPersonalHistoryRepository;

        private Repository<PatientPersonalHistoryDetails> _patientPersonalHistoryDetailsRepository;
        private Repository<PatientPrescription> _patientPrescriptionRepository;
        private Repository<PatientSpecialNote> _patientSpecialNoteRepository;

        private Repository<PatientTreatment> _patientTreatmentRepository;
        private Repository<ReportScanCopy> _reportScanCopyRepository;
        private Repository<AppAppointmentSystemUser> _appAppointmentSystemUserRepository;
        private Repository<AppMedicineCornerUser> _appMedicineCornerUserRepository;

        private Repository<AppPatientManagementUser> _appPatientManagementUserRepository;
        private Repository<AppUser> _appUserRepository;
        private Repository<InsuranceCompany> _insuranceCompanyRepository;
        private Repository<InsurancePlan> _insurancePlanRepository;
        private Repository<EmergencyContact> _emergencyContanctRepository;

        private Repository<Cabin> _cabinRepository;
        private Repository<CabinType> _cabinTypeRepository;
        private Repository<CabinRent> _cabinRentRepository;
        private Repository<CabinAmenity> _cabinAmenityRepository;
        private Repository<TestRequest> _testRequestRepository;
        private Repository<LC> _lcRepository;
        private Repository<OperationType> _operationTypeRepository;

        private Repository<Ward> _wardRepository;
        private Repository<WardType> _wardTypeRepository;
        private Repository<LabItem> _labItemRepository;



        private Repository<Specimen> _SpecimenRepository;
        private Repository<MicrobiologyTest> _MicrobiologyTestRepository;

        private Repository<StoreItem> _storeItemRepository;
        private Repository<StockIn> _stockInRepository;
        private Repository<StockInDetails> _stockInDetailsRepository;
        private Repository<StockOutItem> _stockOutItemRepository;
        private Repository<StockOutDetails> _stockOutDetailsRepository;
        private Repository<StoreRequisition> _storeRequisitionRepository;
        private Repository<StoreRequisitionDetails> _storeRequisitionDetailsRepository;
        private Repository<PurchaseOrder> _purchaseOrderRepository;
        private Repository<PurchaseOrderDetails> _purchaseOrderDetailsRepository;

        private Repository<PharmacyRequisition> _pharmacyRequisitionRepository;
        private Repository<PharmacyRequisitionDetails> _pharmacyRequisitionDetailsRepository;
        private Repository<RETest> _reTestRepository;

        private Repository<SRETest> _sreTestRepository;
        private Repository<CBCTest> _cbcTestRepository;
        private Repository<Bed> _bedRepository;

        private Repository<Purpose> _purposeRepository;
        private Repository<PatientAdmission> _patientAdmissionRepository;
        private Repository<PatientAdmissionDetails> _patientAdmissionDetailsRepository;
        private Repository<DepartmentDetailsForItem> _departmentDetailsForItemRepository;
        private Repository<PatientLaser> _patientLaserRepository;


        private Repository<InPatientDailyBill> _inPatientDailyBillRepository;
        private Repository<InPatientDailyBillDetails> _inPatientDailyBillDetailsRepository;

        private Repository<InPatientDrug> _inPatientDrugRepository;
        private Repository<InPatientDrugDetails> _inPatientDrugDetailsRepository;

        private Repository<ItemStockOut> _itemStockOutRepository;
        private Repository<ItemStockOutDetails> _itemStockOutDetailsRepository;

        private Repository<InPatientDischarge> _inPatientDischargeRepository;
        private Repository<IpdDraft> _inPatientDischargeDraftRepository;
        private Repository<InPatientDoctorInvoice> _inPatientDoctorInvoiceRepository;



        private Repository<InPatientTest> _inPatientTestRepository;
        private Repository<InPatientTestdetails> _inPatientTestdetailsRepository;



        private Repository<OptPatientBill> _optPatientBillRepository;
        private Repository<OptPatientBillDetails> _optPatientBillDetailsRepository;

        private Repository<Product> _productRepository;
        private Repository<Category> _categoryRepository;



        private Repository<Sells> _sellsRepository;
        private Repository<SellsDetails> _sellsDetailsRepository;


        private Repository<CanteenFoodInPatient> _canteenFoodInPatientRepository;
        private Repository<CanteenFoodInPatientDetails> _canteenFoodInPatientDetailsRepository;
        private Repository<DrugDepartmentWiseStockIn> _drugDepartmentWiseStockInRepository;


        private Repository<Package> _packageRepository;
        private Repository<PackageDetails> _packageDetailsRepository;
        private Repository<PackageExcludes> _packageExcludesRepository;

        private Repository<Vehicle> _vehicleRepository;
        private Repository<RentAmbulance> _rentAmbulanceRepository;


        private Repository<InPatientDrugSaleReturn> _inPatientDrugSaleReturnRepository;
        private Repository<InPatientDrugSaleReturnDetails> _inPatientDrugSaleReturnDetailsRepository;


        private Repository<DrugDepartmentWiseStockOut> _drugDepartmentWiseStockOutRepository;
        private Repository<DrugDepartmentWiseStockOutDetails> _drugDepartmentWiseStockOutDetailsRepository;


        private Repository<DrugDepartmentWiseStockInDetails> _drugDepartmentWiseStockInDetailsRepository;

        private Repository<Physiotherapy> _physiotherapyRepository;

        private Repository<OPDTherapy> _oPDTherapyRepository;
        private Repository<OpdTherapyDetails> _oPDTherapyDetailsRepository;

        private Repository<PackageForCheckUp> _packageForChekupRepository;
        private Repository<PackageForCheckupDetails> _packageForChekupDetailsRepository;


        private Repository<ICU> _iCURepository;
        private Repository<ICUBeds> _iCUBedsRepository;
        private Repository<ICURent> _iCURentRepository;
        private Repository<InPatientTransfer> _inPatientTransferRepository;
        private Repository<InPatientTransferBack> _inPatientTransferBackRepository;

        private Repository<BillingForCheckupPackage> _billingForCheckupPackageRepository;
        private Repository<BillingForCheckupPackageDetails> _billingForCheckupPackageDetailsRepository;

        private Repository<InPatientDischargeSummary> _inPatientDischargeSummaryRepository;
        private Repository<PrescriptionAttatchment> _prescriptionAttatchmentRepository;
        private Repository<PatientTestReportAttatchment> _patientTestReportAttatchmentRepository;

        private Repository<OperationTheatre> _operationTheatreRepository;
        private Repository<SurgeonName> _surgeonNameRepository;
        private Repository<PurposeOnOT> _purposeOnOTRepository;
        private Repository<Anesthesia> _anesthesiaRepository;

        private Repository<SEROLOGY> _serologyRepository;
        private Repository<ENDOCRINOLOGY> _endocrinologyRepository;
        private Repository<BioChemistry> _bioChemistryRepository;
        private Repository<IMMUNOLOGICAL> _immunologicalRepository;
        private Repository<PatientCard> _patientCardRepository;


        private Repository<PatientDueCollection> _patientDueCollectionRepository;

        private Repository<PatientAppointmentDialysis> _patientAppointmentDialysisRepository;
        private Repository<VW_DRUG_STOCK> _drugStockViewRepository;
        private Repository<VW_DRUG_AVILABLE_STOCK> _vwDrugAvilableStockRepository;
        private Repository<VW_DRUG_SALE_ALL> _vwDrugSaleAllRepository;
        private Repository<VW_IPD_DRUG_SALE> _vwIpdDrugSalleRepository;
        private Repository<VW_DRUG_CONDITION> _vwDrugConditionRepository;
        private Repository<VW_IPD_DRUG_SALE_RETURN> _vwIpdDrugSalleReturnRepository;
 private Repository<VW_IPD_DRUG_SALE_TOTAL> _vwIpdDrugSalleTotalRepository;
        private Repository<VW_Department_Wise_DRUG_STOCK> _vW_Department_Wise_DRUG_STOCKRepositoryRepository;
        private Repository<VW_Department1_Wise_DRUG_STOCK> _vW_Department1_Wise_DRUG_STOCKRepository;
        private Repository<VW_DAILY_USER_COLLECTION> _vwDailyUserCollectionRepository;

        private Repository<StoreItemCategory> _storeItemCategoryRepository;
        private Repository<AssistantDoctor> _assistantDoctorRepository;

        private Repository<CabinToCabinTransfer> _cabinToCabinTransferRepository;
        private Repository<CabinTransferBack> _cabinTransferBackRepository;
        private Repository<MerketingBy> _merketingByRepository;
        private Repository<OpdTherapyDueCollection> _opdTherapyDueColletionRepository;
        private Repository<OpdPatientDuebillCollection> _opdPatientDuebillCollectionRepository;

        private Repository<InPatientDischargeDueCollection> _inPatientDischargeDueCollectionRepository;


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Repository<OpdTherapyDueCollection> OpdTherapyDueCollectionRepository
        {
            get { return _opdTherapyDueColletionRepository ?? (_opdTherapyDueColletionRepository = new OpdTherapyDueCollectionRepository(_context)); }
        }

        public Repository<OpdPatientDuebillCollection> OpdPatientDuebillCollectionRepository
        {
            get { return _opdPatientDuebillCollectionRepository ?? (_opdPatientDuebillCollectionRepository = new OpdPatientDuebillCollectionRepository(_context)); }
        }





        public Repository<InPatientDischargeDueCollection> InPatientDischargeDueCollectionRepository
        {
            get { return _inPatientDischargeDueCollectionRepository ?? (_inPatientDischargeDueCollectionRepository = new InPatientDischargeDueCollectionRepository(_context)); }
        }
        public Repository<MerketingBy> MerketingByRepository
        {
            get { return _merketingByRepository ?? (_merketingByRepository = new MerketingByRepository(_context)); }
        }


        public Repository<CabinTransferBack> CabinTransferBackRepository
        {
            get { return _cabinTransferBackRepository ?? (_cabinTransferBackRepository = new CabinTransferBackRepository(_context)); }
        }
        public Repository<CabinToCabinTransfer> CabinToCabinTransferRepository
        {
            get { return _cabinToCabinTransferRepository ?? (_cabinToCabinTransferRepository = new CabinToCabinTransferRepository(_context)); }
        }

        public Repository<AssistantDoctor> AssistantDoctorRepository
        {
            get { return _assistantDoctorRepository ?? (_assistantDoctorRepository = new AssistantDoctorRepository(_context)); }
        }
        public Repository<StoreItemCategory> StoreItemCategoryRepository
        {
            get { return _storeItemCategoryRepository ?? (_storeItemCategoryRepository = new StoreItemCategoryRepository(_context)); }
        }


        public Repository<VW_Department1_Wise_DRUG_STOCK> VW_Department1_Wise_DRUG_STOCKRepository
        {
            get { return _vW_Department1_Wise_DRUG_STOCKRepository ?? (_vW_Department1_Wise_DRUG_STOCKRepository = new VW_Department1_Wise_DRUG_STOCKRepository(_context)); }
        }
        public Repository<VW_Department_Wise_DRUG_STOCK> VW_Department_Wise_DRUG_STOCKRepository
        {
            get { return _vW_Department_Wise_DRUG_STOCKRepositoryRepository ?? (_vW_Department_Wise_DRUG_STOCKRepositoryRepository = new VW_Department_Wise_DRUG_STOCKRepository(_context)); }
        }
        public Repository<VW_DRUG_STOCK> DrugStockViewRepository
        {
            get { return _drugStockViewRepository ?? (_drugStockViewRepository = new DrugStockViewRepository(_context)); }
        }

        public Repository<VW_DRUG_AVILABLE_STOCK> VwDrugAvilableRepository
        {
            get { return _vwDrugAvilableStockRepository ?? (_vwDrugAvilableStockRepository = new VwDrugAvilableRepository(_context)); }
        }
        public Repository<VW_DRUG_CONDITION> VwDrugConditionRepository
        {
            get { return _vwDrugConditionRepository ?? (_vwDrugConditionRepository = new VwDrugConditionRepository(_context)); }
        }
        public Repository<VW_DRUG_SALE_ALL> VwDrugSaleAllRepository
        {
            get
            {
                return _vwDrugSaleAllRepository ?? (_vwDrugSaleAllRepository = new VwDrugSaleAllRepository(_context)); }
        }
        public Repository<VW_IPD_DRUG_SALE> VwIpdDrugSalleRepository
        {
            get { return _vwIpdDrugSalleRepository ?? (_vwIpdDrugSalleRepository = new VwIpdDrugSaleRepository(_context)); }
        }
        public Repository<VW_IPD_DRUG_SALE_RETURN> VwIpdDrugSalleReturnRepository
        {
            get { return _vwIpdDrugSalleReturnRepository ?? (_vwIpdDrugSalleReturnRepository = new VwIpdDrugSaleReturnRepository(_context)); }
        }
        public Repository<VW_IPD_DRUG_SALE_TOTAL> VwIpdDrugSalleTotalRepository
        {
            get { return _vwIpdDrugSalleTotalRepository ?? (_vwIpdDrugSalleTotalRepository = new VwIpdDrugSaleTotalRepository(_context)); }
        }
        public Repository<VW_DAILY_USER_COLLECTION> VwDailyUserCollectionRepository
        {
            get { return _vwDailyUserCollectionRepository ?? (_vwDailyUserCollectionRepository = new VwDailyUserCollectionRepository(_context)); }
        }
        public Repository<PatientCard> PatientCardRepository
        {
            get { return _patientCardRepository ?? (_patientCardRepository = new PatientCardRepository(_context)); }
        }
        public Repository<SEROLOGY> SEROLOGYRepository
        {
            get { return _serologyRepository ?? (_serologyRepository = new SEROLOGYRepository(_context)); }
        }

        public Repository<PatientAppointmentDialysis> PatientAppointmentDialysisRepository
        {
            get { return _patientAppointmentDialysisRepository ?? (_patientAppointmentDialysisRepository = new PatientAppointmentDialysisRepository(_context)); }
        }
        public Repository<BioChemistry> BioChemistryRepository
        {
            get { return _bioChemistryRepository ?? (_bioChemistryRepository = new BioChemistryRepository(_context)); }
        }

        public Repository<IMMUNOLOGICAL> IMMUNOLOGICALRepository
        {
            get { return _immunologicalRepository ?? (_immunologicalRepository = new IMMUNOLOGICALRepository(_context)); }
        }
        public Repository<ENDOCRINOLOGY> ENDOCRINOLOGYRepository
        {
            get { return _endocrinologyRepository ?? (_endocrinologyRepository = new ENDOCRINOLOGYRepository(_context)); }
        }



        public Repository<PatientDueCollection> PatientDueCollectionRepository
        {
            get { return _patientDueCollectionRepository ?? (_patientDueCollectionRepository = new PatientDueCollectionRepository(_context)); }
        }
        public Repository<Anesthesia> AnesthesiaRepository
        {
            get { return _anesthesiaRepository ?? (_anesthesiaRepository = new AnesthesiaRepository(_context)); }
        }
        public Repository<PurposeOnOT> PurposeOnOTRepository
        {
            get { return _purposeOnOTRepository ?? (_purposeOnOTRepository = new PurposeOnOTRepository(_context)); }
        }
        public Repository<SurgeonName> SurgeonNameRepository
        {
            get { return _surgeonNameRepository ?? (_surgeonNameRepository = new SurgeonNameRepository(_context)); }
        }
        public Repository<OperationTheatre> OperationTheatreRepository
        {
            get { return _operationTheatreRepository ?? (_operationTheatreRepository = new OperationTheatreRepository(_context)); }
        }
        public Repository<PatientTestReportAttatchment> PatientTestReportAttatchmentRepository
        {
            get { return _patientTestReportAttatchmentRepository ?? (_patientTestReportAttatchmentRepository = new PatientTestReportAttatchmentRepository(_context)); }
        }
        public Repository<PrescriptionAttatchment> PrescriptionAttatchmentRepository
        {
            get { return _prescriptionAttatchmentRepository ?? (_prescriptionAttatchmentRepository = new PrescriptionAttatchmentRepository(_context)); }
        }
        public Repository<InPatientDischargeSummary> InPatientDischargeSummariesRepository
        {
            get { return _inPatientDischargeSummaryRepository ?? (_inPatientDischargeSummaryRepository = new InPatientDischargeSummariesRepository(_context)); }
        }
        public Repository<PackageForCheckUp> PackageForCheckUpRepository
        {
            get { return _packageForChekupRepository ?? (_packageForChekupRepository = new PackageForCheckUpRepository(_context)); }
        }
        public Repository<PackageForCheckupDetails> PackageForCheckupDetailsRepository
        {
            get { return _packageForChekupDetailsRepository ?? (_packageForChekupDetailsRepository = new PackageForCheckupDetailsRepository(_context)); }
        }


        public Repository<BillingForCheckupPackage> BillingForCheckupPackageRepository
        {
            get { return _billingForCheckupPackageRepository ?? (_billingForCheckupPackageRepository = new BillingForCheckupPackageRepository(_context)); }
        }
        public Repository<BillingForCheckupPackageDetails> BillingForCheckupPackageDetailsRepository
        {
            get { return _billingForCheckupPackageDetailsRepository ?? (_billingForCheckupPackageDetailsRepository = new BillingForCheckupPackageDetailsRepository(_context)); }
        }



        public Repository<ICURent> ICURentRepository
        {
            get { return _iCURentRepository ?? (_iCURentRepository = new ICURentRepository(_context)); }
        }
        public Repository<CheckInCheckOut> CheckInCheckOutRepository
        {
            get { return _CheckInCheckOutRepository ?? (_CheckInCheckOutRepository = new CheckInCheckOutRepository(_context)); }
        }


        public Repository<ICUBeds> ICUBedsRepository
        {
            get { return _iCUBedsRepository ?? (_iCUBedsRepository = new ICUBedsRepository(_context)); }
        }
        public Repository<InPatientTransferBack> InPatientTransferBackRepository
        {
            get { return _inPatientTransferBackRepository ?? (_inPatientTransferBackRepository = new InPatientTransferBackRepository(_context)); }
        }
        public Repository<InPatientTransfer> InPatientTransferRepository
        {
            get { return _inPatientTransferRepository ?? (_inPatientTransferRepository = new InPatientTransferRepository(_context)); }
        }
        public Repository<ICU> ICURepository
        {
            get { return _iCURepository ?? (_iCURepository = new ICURepository(_context)); }
        }
        public Repository<OpdTherapyDetails> OpdTherapyDetailsRepository
        {
            get { return _oPDTherapyDetailsRepository ?? (_oPDTherapyDetailsRepository = new OpdTherapyDetailsRepository(_context)); }
        }
        public Repository<OPDTherapy> OPDTherapyRepository
        {
            get { return _oPDTherapyRepository ?? (_oPDTherapyRepository = new OPDTherapyRepository(_context)); }
        }
        public Repository<Physiotherapy> PhysiotherapyRepository
        {
            get { return _physiotherapyRepository ?? (_physiotherapyRepository = new PhysiotherapyRepository(_context)); }
        }
        public Repository<DrugDepartmentWiseStockInDetails> DrugDepartmentWiseStockInDetailsRepository
        {
            get { return _drugDepartmentWiseStockInDetailsRepository ?? (_drugDepartmentWiseStockInDetailsRepository = new DrugDepartmentWiseStockInDetailsRepository(_context)); }
        }
        public Repository<DrugDepartmentWiseStockOutDetails> DrugDepartmentWiseStockOutDetailsRepository
        {
            get { return _drugDepartmentWiseStockOutDetailsRepository ?? (_drugDepartmentWiseStockOutDetailsRepository = new DrugDepartmentWiseStockOutDetailsRepository(_context)); }
        }
        public Repository<Vehicle> VehicleRepository
        {
            get { return _vehicleRepository ?? (_vehicleRepository = new VehicleRepository(_context)); }
        }
        public Repository<RentAmbulance> RentAmbulanceRepository
        {
            get { return _rentAmbulanceRepository ?? (_rentAmbulanceRepository = new RentAmbulanceRepository(_context)); }
        }

        public Repository<DrugDepartmentWiseStockOut> DrugDepartmentWiseStockOutRepository
        {
            get { return _drugDepartmentWiseStockOutRepository ?? (_drugDepartmentWiseStockOutRepository = new DrugDepartmentWiseStockOutRepository(_context)); }
        }
        public Repository<InPatientDrugSaleReturn> InPatientDrugSaleReturnRepository
        {
            get { return _inPatientDrugSaleReturnRepository ?? (_inPatientDrugSaleReturnRepository = new InPatientDrugSaleReturnRepository(_context)); }
        }
        public Repository<InPatientDrugSaleReturnDetails> InPatientDrugSaleReturnDetailsRepository
        {
            get { return _inPatientDrugSaleReturnDetailsRepository ?? (_inPatientDrugSaleReturnDetailsRepository = new InPatientDrugSaleReturnDetailsRepository(_context)); }
        }
        public Repository<PackageExcludes> PackageExcludesRepository
        {
            get { return _packageExcludesRepository ?? (_packageExcludesRepository = new PackageExcludesRepository(_context)); }
        }
        public Repository<PackageDetails> PackageDetailsRepository
        {
            get { return _packageDetailsRepository ?? (_packageDetailsRepository = new PackageDetailsRepository(_context)); }
        }
        public Repository<Package> PackageRepository
        {
            get { return _packageRepository ?? (_packageRepository = new PackageRepository(_context)); }
        }
        public Repository<CanteenFoodInPatient> CanteenFoodInPatientRepository
        {
            get { return _canteenFoodInPatientRepository ?? (_canteenFoodInPatientRepository = new CanteenFoodInPatientRepository(_context)); }
        }
        public Repository<CanteenFoodInPatientDetails> CanteenFoodInPatientDetailsRepository
        {
            get { return _canteenFoodInPatientDetailsRepository ?? (_canteenFoodInPatientDetailsRepository = new CanteenFoodInPatientDetailsRepository(_context)); }
        }

        public Repository<DrugDepartmentWiseStockIn> DrugDepartmentWiseStockInRepository
        {
            get { return _drugDepartmentWiseStockInRepository ?? (_drugDepartmentWiseStockInRepository = new DrugDepartmentWiseStockInRepository(_context)); }
        }
        public Repository<Product> ProductRepository
        {
            get { return _productRepository ?? (_productRepository = new ProductRepository(_context)); }
        }
        public Repository<Category> CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context)); }
        }

        public Repository<Sells> SellsRepository
        {
            get { return _sellsRepository ?? (_sellsRepository = new SellsRepository(_context)); }
        }
        public Repository<SellsDetails> SellsDetailsRepository
        {
            get { return _sellsDetailsRepository ?? (_sellsDetailsRepository = new SellsDetailsRepository(_context)); }
        }



        public Repository<StoreRequisition> StoreRequisitionRepository
        {
            get { return _storeRequisitionRepository ?? (_storeRequisitionRepository = new StoreRequisitionRepository(_context)); }
        }
        public Repository<StoreRequisitionDetails> StoreRequisitionDetailsRepository
        {
            get { return _storeRequisitionDetailsRepository ?? (_storeRequisitionDetailsRepository = new StoreRequisitionDetailsRepository(_context)); }
        }

        public Repository<OptPatientBillDetails> OptPatientBillDetailsRepository
        {
            get { return _optPatientBillDetailsRepository ?? (_optPatientBillDetailsRepository = new OptPatientBillDetailsRepository(_context)); }
        }
        public Repository<OptPatientBill> OptPatientBillRepository
        {
            get { return _optPatientBillRepository ?? (_optPatientBillRepository = new OptPatientBillRepository(_context)); }
        }
        public Repository<ItemStockOut> ItemStockOutRepository
        {
            get { return _itemStockOutRepository ?? (_itemStockOutRepository = new ItemStockOutRepository(_context)); }
        }
        public Repository<ItemStockOutDetails> ItemStockOutDetailsRepository
        {
            get { return _itemStockOutDetailsRepository ?? (_itemStockOutDetailsRepository = new ItemStockOutDetailsRepository(_context)); }
        }
        public Repository<DepartmentDetailsForItem> DepartmentDetailsForItemRepository
        {
            get { return _departmentDetailsForItemRepository ?? (_departmentDetailsForItemRepository = new DepartmentDetailsForItemRepository(_context)); }
        }






        public Repository<InPatientTestdetails> InPatientTestdetailsRepository
        {
            get { return _inPatientTestdetailsRepository ?? (_inPatientTestdetailsRepository = new InPatientTestdetailsRepository(_context)); }
        }
        public Repository<InPatientTest> InPatientTestRepository
        {
            get { return _inPatientTestRepository ?? (_inPatientTestRepository = new InPatientTestRepository(_context)); }
        }
        public Repository<InPatientDoctorInvoice> InPatientDoctorInvoiceRepository
        {
            get { return _inPatientDoctorInvoiceRepository ?? (_inPatientDoctorInvoiceRepository = new InPatientDoctorInvoiceRepository(_context)); }
        }
        public Repository<InPatientDischarge> InPatientDischargeRepository
        {
            get { return _inPatientDischargeRepository ?? (_inPatientDischargeRepository = new InPatientDischargeRepository(_context)); }
        }
        public Repository<IpdDraft> InPatientDischargeDraftRepository
        {
            get { return _inPatientDischargeDraftRepository ?? (_inPatientDischargeDraftRepository = new InPatientDischargeDraftRepository(_context)); }
        }
        public Repository<InPatientDrugDetails> InPatientDrugDetailsRepository
        {
            get { return _inPatientDrugDetailsRepository ?? (_inPatientDrugDetailsRepository = new InPatientDrugDetailsRepository(_context)); }
        }
        public Repository<InPatientDrug> InPatientDrugRepository
        {
            get { return _inPatientDrugRepository ?? (_inPatientDrugRepository = new InPatientDrugRepository(_context)); }
        }

        public Repository<InPatientDailyBill> InPatientDailyBillRepository
        {
            get { return _inPatientDailyBillRepository ?? (_inPatientDailyBillRepository = new InPatientDailyBillRepository(_context)); }
        }

        public Repository<InPatientDailyBillDetails> InPatientDailyBillDetailsRepository
        {
            get { return _inPatientDailyBillDetailsRepository ?? (_inPatientDailyBillDetailsRepository = new InPatientDailyBillDetailsRepository(_context)); }
        }
        public Repository<Bed> BedRepository
        {
            get { return _bedRepository ?? (_bedRepository = new BedRepository(_context)); }
        }
        public Repository<PatientLaser> PatientLaserRepository
        {
            get { return _patientLaserRepository ?? (_patientLaserRepository = new PatientLaserRepository(_context)); }
        }
        public Repository<Purpose> PurposeRepository
        {
            get { return _purposeRepository ?? (_purposeRepository = new PurposeRepository(_context)); }
        }

        public Repository<PatientAdmission> PatientAdmissionRepository
        {
            get { return _patientAdmissionRepository ?? (_patientAdmissionRepository = new PatientAdmissionRepository(_context)); }
        }

        public Repository<PatientAdmissionDetails> PatientAdmissionDetailsRepository
        {
            get { return _patientAdmissionDetailsRepository ?? (_patientAdmissionDetailsRepository = new PatientAdmissionDetailsRepository(_context)); }
        }
        public Repository<RETest> RETestRepository
        {
            get { return _reTestRepository ?? (_reTestRepository = new RETestRepository(_context)); }
        }

        public Repository<SRETest> SRETestRepository
        {
            get { return _sreTestRepository ?? (_sreTestRepository = new SRETestRepository(_context)); }
        }
        public Repository<CBCTest> CBCTestRepository
        {
            get { return _cbcTestRepository ?? (_cbcTestRepository = new CBCTestRepository(_context)); }
        }

        public Repository<PharmacyRequisition> PharmacyRequisitionRepository
        {
            get { return _pharmacyRequisitionRepository ?? (_pharmacyRequisitionRepository = new PharmacyRequisitionRepository(_context)); }
        }

        public Repository<PharmacyRequisitionDetails> PharmacyRequisitionDetailsRepository
        {
            get { return _pharmacyRequisitionDetailsRepository ?? (_pharmacyRequisitionDetailsRepository = new PharmacyRequisitionDetailsRepository(_context)); }
        }

        public Repository<PurchaseOrderDetails> PurchaseOrderDetailsRepository
        {
            get { return _purchaseOrderDetailsRepository ?? (_purchaseOrderDetailsRepository = new PurchaseOrderDetailsRepository(_context)); }
        }

        public Repository<PurchaseOrder> PurchaseOrderRepository
        {
            get { return _purchaseOrderRepository ?? (_purchaseOrderRepository = new PurchaseOrderRepository(_context)); }
        }
        public Repository<StockInDetails> StockInDetailsRepository
        {
            get { return _stockInDetailsRepository ?? (_stockInDetailsRepository = new StockInDetailsRepository(_context)); }
        }
        public Repository<StockIn> StockInRepository
        {
            get { return _stockInRepository ?? (_stockInRepository = new StockInRepository(_context)); }
        }

        public Repository<StockOutDetails> StockOutDetailsRepository
        {
            get { return _stockOutDetailsRepository ?? (_stockOutDetailsRepository = new StockOutDetailsRepository(_context)); }
        }
        public Repository<StockOutItem> StockOutItemRepository
        {
            get { return _stockOutItemRepository ?? (_stockOutItemRepository = new StockOutItemRepository(_context)); }
        }
        public Repository<StoreItem> StoreItemRepository
        {
            get { return _storeItemRepository ?? (_storeItemRepository = new StoreItemRepository(_context)); }
        }

        public Repository<MicrobiologyTest> MicrobiologyTestRepository
        {
            get { return _MicrobiologyTestRepository ?? (_MicrobiologyTestRepository = new MicrobiologyTestRepository(_context)); }
        }

        public Repository<Specimen> SpecimenRepository
        {
            get { return _SpecimenRepository ?? (_SpecimenRepository = new SpecimenRepository(_context)); }
        }
        public Repository<LabItem> LabItemRepository
        {
            get { return _labItemRepository ?? (_labItemRepository = new LabItemRepository(_context)); }
        }
        public Repository<Ward> WardRepository
        {
            get { return _wardRepository ?? (_wardRepository = new WardRepository(_context)); }
        }
        public Repository<WardType> WardTypeRepository
        {
            get { return _wardTypeRepository ?? (_wardTypeRepository = new WardTypeRepository(_context)); }
        }
        public Repository<OperationType> OperationTypeRepository
        {
            get { return _operationTypeRepository ?? (_operationTypeRepository = new OperationTypeRepository(_context)); }
        }
        public Repository<TestRequest> TestRequestRepository
        {
            get { return _testRequestRepository ?? (_testRequestRepository = new TestRequestRepository(_context)); }
        }
        public Repository<Cabin> CabinRepository
        {
            get { return _cabinRepository ?? (_cabinRepository = new CabinRepository(_context)); }
        }

        public Repository<CabinType> CabinTypeRepository
        {
            get { return _cabinTypeRepository ?? (_cabinTypeRepository = new CabinTypeRepository(_context)); }
        }

        public Repository<CabinRent> CabinRentRepository
        {
            get { return _cabinRentRepository ?? (_cabinRentRepository = new CabinRentRepository(_context)); }
        }

        public Repository<CabinAmenity> CabinAmenityRepository
        {
            get { return _cabinAmenityRepository ?? (_cabinAmenityRepository = new CabinAmenityRepository(_context)); }
        }
        public Repository<PatientEducation> PatientEducationRepository
        {
            get { return _patientEducationRepository ?? (_patientEducationRepository = new PatientEducationRepository(_context)); }
        }

        public Repository<LC> LCRepository
        {
            get { return _lcRepository ?? (_lcRepository = new LCRepository(_context)); }
        }
        public Repository<DrugSaleDetailsHistory> DrugSaleDetailsHistoryRepository
        {
            get { return _drugSaleDetailsHistoryRepository ?? (_drugSaleDetailsHistoryRepository = new DrugSaleDetailsHistoryRepository(_context)); }
        }
        public Repository<DrugSaleHistory> DrugSaleHistoryRepository
        {
            get { return _drugSaleHistoryRepository ?? (_drugSaleHistoryRepository = new DrugSaleHistoryRepository(_context)); }
        }
        public Repository<EmergencyContact> EmergencyContactRepository
        {
            get { return _emergencyContanctRepository ?? (_emergencyContanctRepository = new EmergencyContactRepository(_context)); }
        }
        public Repository<InsurancePlan> InsurancePlanRepository
        {
            get { return _insurancePlanRepository ?? (_insurancePlanRepository = new InsurancePlanRepository(_context)); }
        }
        public Repository<InsuranceCompany> InsuranceCompanyRepository
        {
            get { return _insuranceCompanyRepository ?? (_insuranceCompanyRepository = new InsuranceCompanyRepository(_context)); }
        }

        public Repository<DrugSaleDetails> DrugSaleDetailsRepository
        {
            get { return _drugSaleDetailsRepository ?? (_drugSaleDetailsRepository = new DrugSaleDetailsRepository(_context)); }
        }
        public Repository<AppUser> AppUserRepository
        {
            get { return _appUserRepository ?? (_appUserRepository = new AppUserRepository(_context)); }
        }
        public Repository<AppPatientManagementUser> AppPatientManagementUserRepository
        {
            get { return _appPatientManagementUserRepository ?? (_appPatientManagementUserRepository = new AppPatientManagementUserRepository(_context)); }
        }
        public Repository<AppMedicineCornerUser> AppMedicineCornerUserRepository
        {
            get { return _appMedicineCornerUserRepository ?? (_appMedicineCornerUserRepository = new AppMedicineCornerUserRepository(_context)); }
        }
        public Repository<AppAppointmentSystemUser> AppAppointmentSystemUserRepository
        {
            get { return _appAppointmentSystemUserRepository ?? (_appAppointmentSystemUserRepository = new AppAppointmentSystemUserRepository(_context)); }
        }
        public Repository<ReportScanCopy> ReportScanCopyRepository
        {
            get { return _reportScanCopyRepository ?? (_reportScanCopyRepository = new ReportScanCopyRepository(_context)); }
        }
        public Repository<PatientTreatment> PatientTreatmentRepository
        {
            get { return _patientTreatmentRepository ?? (_patientTreatmentRepository = new PatientTreatmentRepository(_context)); }
        }
        public Repository<PatientSpecialNote> PatientSpecialNoteRepository
        {
            get { return _patientSpecialNoteRepository ?? (_patientSpecialNoteRepository = new PatientSpecialNoteRepository(_context)); }
        }
        public Repository<PatientPrescription> PatientPrescriptionRepository
        {
            get { return _patientPrescriptionRepository ?? (_patientPrescriptionRepository = new PatientPrescriptionRepository(_context)); }
        }
        public Repository<PatientPersonalHistoryDetails> PatientPersonalHistoryDetailsRepository
        {
            get { return _patientPersonalHistoryDetailsRepository ?? (_patientPersonalHistoryDetailsRepository = new PatientPersonalHistoryDetailsRepository(_context)); }
        }
        public Repository<PatientPersonalHistory> PatientPersonalHistoryRepository
        {
            get { return _patientPersonalHistoryRepository ?? (_patientPersonalHistoryRepository = new PatientPersonalHistoryRepository(_context)); }
        }
        public Repository<PatientPersonalAttribute> PatientPersonalAttributeRepository
        {
            get { return _patientPersonalAttributeRepository ?? (_patientPersonalAttributeRepository = new PatientPersonalAttributeRepository(_context)); }
        }
        public Repository<PatientPastIllness> PatientPastIllnessRepository
        {
            get { return _patientPastIllnessRepository ?? (_patientPastIllnessRepository = new PatientPastIllnessRepository(_context)); }
        }
        public Repository<PatientPastHistoryOfMadication> PatientPastHistoryOfMadicationRepository
        {
            get { return _patientPastHistoryOfMadicationRepository ?? (_patientPastHistoryOfMadicationRepository = new PatientPastHistoryOfMadicationRepository(_context)); }
        }
        public Repository<PatientOldInvestigation> PatientOldInvestigationRepository
        {
            get { return _patientOldInvestigationRepository ?? (_patientOldInvestigationRepository = new PatientOldInvestigationRepository(_context)); }
        }
        public Repository<PatientInvestigation> PatientInvestigationRepository
        {
            get { return _patientInvestigationRepository ?? (_patientInvestigationRepository = new PatientInvestigationRepository(_context)); }
        }
        public Repository<PatientInformation> PatientInformationRepository
        {
            get { return _patientInformationRepository ?? (_patientInformationRepository = new PatientInformationRepository(_context)); }
        }
        public Repository<PatientHistory> PatientHistoryRepository
        {
            get { return _patientHistoryExamRepository ?? (_patientHistoryExamRepository = new PatientHistoryRepository(_context)); }
        }
        public Repository<PatientGeneralExam> PatientGeneralExamRepository
        {
            get { return _patientGeneralExamRepository ?? (_patientGeneralExamRepository = new PatientGeneralExamRepository(_context)); }
        }
        public Repository<PatientFamilyDisease> PatientFamilyDiseaseRepository
        {
            get { return _patientFamilyDiseaseRepository ?? (_patientFamilyDiseaseRepository = new PatientFamilyDiseaseRepository(_context)); }
        }
        public Repository<PatientEnroll> PatientEnrollRepository
        {
            get { return _patientEnrollRepository ?? (_patientEnrollRepository = new PatientEnrollRepository(_context)); }
        }
        public Repository<PatientChiefComplaint> PatientChiefComplaintRepository
        {
            get { return _patientChiefComplaintRepository ?? (_patientChiefComplaintRepository = new PatientChiefComplaintRepository(_context)); }
        }
        public Repository<PatientAllergyInformation> PatientAllergyInformationRepository
        {
            get { return _patientAllergyInformationRepository ?? (_patientAllergyInformationRepository = new PatientAllergyInformationRepository(_context)); }
        }
        public Repository<ChiefComplaint> ChiefComplaintRepository
        {
            get { return _chiefComplaintRepository ?? (_chiefComplaintRepository = new ChiefComplaintRepository(_context)); }
        }
        public Repository<ChiefComplaintDuration> ChiefComplaintDurationRepository
        {
            get { return _chiefComplaintDurationRepository ?? (_chiefComplaintDurationRepository = new ChiefComplaintDurationRepository(_context)); }
        }
        public Repository<DrugsSelectedGroups> DrugsSelectedGroupsRepository
        {
            get { return _drugsSelectedGroupsRepository ?? (_drugsSelectedGroupsRepository = new DrugsSelectedGroupsRepository(_context)); }
        }
        public Repository<DrugSaleReturn> DrugSaleReturnRepository
        {
            get { return _drugSaleReturnRepository ?? (_drugSaleReturnRepository = new DrugSaleReturnRepository(_context)); }
        }
        public Repository<DrugInvoicePayment> DrugInvoicePaymentRepository
        {
            get { return _drugInvoicePaymentRepository ?? (_drugInvoicePaymentRepository = new DrugInvoicePaymentRepository(_context)); }
        }
        public Repository<DrugDuration> DrugDurationRepository
        {
            get { return _drugDurationRepository ?? (_drugDurationRepository = new DrugDurationRepository(_context)); }
        }
        public Repository<DrugDoseChart> DrugDoseChartRepository
        {
            get { return _drugDoseChartRepository ?? (_drugDoseChartRepository = new DrugDoseChartRepository(_context)); }
        }
        public Repository<DrugDailyStockHistory> DrugDailyStockHistoryRepository
        {
            get { return _drugDailyStockHistoryRepository ?? (_drugDailyStockHistoryRepository = new DrugDailyStockHistoryRepository(_context)); }
        }
        public Repository<OperationNote> OperationNoteRepository
        {
            get { return _operationNoteRepository ?? (_operationNoteRepository = new OperationNoteRepository(_context)); }
        }
        public Repository<SpecialNote> SpecialNoteRepository
        {
            get { return _specialNoteRepository ?? (_specialNoteRepository = new SpecialNoteRepository(_context)); }
        }
        public Repository<SocialEconomicStatus> SocialEconomicStatusRepository
        {
            get { return _socialEconomicStatusRepository ?? (_socialEconomicStatusRepository = new SocialEconomicStatusRepository(_context)); }
        }
        public Repository<Occupation> OccupationRepository
        {
            get { return _occupationRepository ?? (_occupationRepository = new OccupationRepository(_context)); }
        }
        public Repository<MsAmountPurpose> MsAmountPurposeRepository
        {
            get { return _msAmountPurposeRepository ?? (_msAmountPurposeRepository = new MsAmountPurposeRepository(_context)); }
        }
        public Repository<FamilyTree> FamilyTreeRepository
        {
            get { return _familyTreeRepository ?? (_familyTreeRepository = new FamilyTreeRepository(_context)); }
        }
        public Repository<Education> EducationRepository
        {
            get { return _educationRepository ?? (_educationRepository = new EducationRepository(_context)); }
        }
        public Repository<DiseaseCondition> DiseaseConditionRepository
        {
            get { return _diseaseConditionRepository ?? (_diseaseConditionRepository = new DiseaseConditionRepository(_context)); }
        }
        public Repository<Disease> DiseaseRepository
        {
            get { return _diseaseRepository ?? (_diseaseRepository = new DiseaseRepository(_context)); }
        }
        public Repository<HospitalInformation> HospitalInformationRepository
        {
            get { return _hospitalInformationRepository ?? (_hospitalInformationRepository = new HospitalInformationRepository(_context)); }
        }
        public Repository<VisitDiscount> VisitDiscountRepository
        {
            get { return _visitDiscountRepository ?? (_visitDiscountRepository = new VisitDiscountRepository(_context)); }
        }
        public Repository<DoctorNote> DoctorNoteRepository
        {
            get { return _doctorNoteRepository ?? (_doctorNoteRepository = new DoctorNoteRepository(_context)); }
        }
        public Repository<DoctorInformation> DoctorInformationRepository
        {
            get { return _doctorInformationRepository ?? (_doctorInformationRepository = new DoctorInformationRepository(_context)); }
        }
        public Repository<DoctorAppointment> DoctorAppointmentRepository
        {
            get { return _doctorAppointmentRepository ?? (_doctorAppointmentRepository = new DoctorAppointmentRepository(_context)); }
        }
        public Repository<DoctorAppointmentPayment> DoctorAppointmentPaymentRepository
        {
            get { return _doctorAppointmentPaymentRepository ?? (_doctorAppointmentPaymentRepository = new DoctorAppointmentPaymentRepository(_context)); }
        }

        public Repository<DoctorBusinessHoliday> DoctorBusinessHolidayRepository
        {
            get { return _doctorBusinessHolidayRepository ?? (_doctorBusinessHolidayRepository = new DoctorBusinessHolidayRepository(_context)); }
        }
        public Repository<AllergyInformation> AllergyInformationRepository
        {
            get { return _allergyInformationRepository ?? (_allergyInformationRepository = new AllergyInformationRepository(_context)); }
        }


        public Repository<AllergySubstance> AllergySubstanceRepository
        {
            get { return _allergySubstanceRepository ?? (_allergySubstanceRepository = new AllergySubstanceRepository(_context)); }
        }



        public Repository<DrugSale> DrugSaleRepository
        {
            get { return _drugSaleRepository ?? (_drugSaleRepository = new DrugSaleRepository(_context)); }
        }
        public Repository<ShiftInfo> ShiftInfoRepository
        {
            get { return _shiftInfoRepository ?? (_shiftInfoRepository = new ShiftInfoRepository(_context)); }
        }

        public Repository<Holiday> HolidayRepository
        {
            get { return _holidayRepository ?? (_holidayRepository = new HolidayRepository(_context)); }
        }
        public Repository<LoanConfig> LoanConfigRepository
        {
            get { return _loanConfigRepository ?? (_loanConfigRepository = new LoanConfigRepository(_context)); }
        }
        public Repository<loanConfigPlan> LoanConfigPlanRepository
        {
            get { return _loanConfigPlanRepository ?? (_loanConfigPlanRepository = new LoanConfigPlanRepository(_context)); }
        }

        public Repository<TaxConfiguration> TaxConfigurationRepository
        {
            get { return _taxConfigurationRepository ?? (_taxConfigurationRepository = new TaxConfigurationRepository(_context)); }
        }



        public Repository<DrugStockDetails> DrugStockDetailsRepository
        {
            get { return _drugStockDetailsRepository ?? (_drugStockDetailsRepository = new DrugStockDetailsRepository(_context)); }
        }
        public Repository<DrugStockIn> DrugStockInRepository
        {
            get { return _drugStockInRepository ?? (_drugStockInRepository = new DrugStockInRepository(_context)); }
        }
        public Repository<DrugGroup> DrugGroupRepository
        {
            get { return _drugGroupRepository ?? (_drugGroupRepository = new DrugGroupRepository(_context)); }
        }
        public Repository<DrugDose> DrugDoseRepository
        {
            get { return _drugDoseRepository ?? (_drugDoseRepository = new DrugDoseRepository(_context)); }
        }
        public Repository<OccurrenceType> OccurrenceTypeRepository
        {
            get { return _occurrenceTypeRepository ?? (_occurrenceTypeRepository = new OccurrenceTypeRepository(_context)); }
        }

        public Repository<Occurrence> OccurrenceRepository
        {
            get { return _occurrenceRepository ?? (_occurrenceRepository = new OccurrenceRepository(_context)); }
        }
        public Repository<DailyExpense> DailyExpenseRepository
        {
            get { return _dailyExpenseRepository ?? (_dailyExpenseRepository = new DailyExpenseRepository(_context)); }
        }


        public Repository<PatientDetails> PatientDetailsRepository
        {
            get { return _patientDetailsRepository ?? (_patientDetailsRepository = new PatientDetailsRepository(_context)); }
        }
        public Repository<Patient> PatientRepository
        {
            get { return _patientRepository ?? (_patientRepository = new PatientRepository(_context)); }
        }
        public Repository<EmployeeInfo> EmployeeInfoRepository
        {
            get { return _employeeInfoRepository ?? (_employeeInfoRepository = new EmployeeInfoRepository(_context)); }
        }
        public Repository<EmployeeAttendenceCheckInOut> EmployeeAttendanceRepository
        {
            get { return _employeeAttendanceRepository ?? (_employeeAttendanceRepository = new EmployeeAttendanceRepository(_context)); }
        }
        public Repository<LeaveOfAbsenceDetails> LeaveOfAbsenceDetailsRepository
        {
            get { return _leaveOfAbsenceDetails ?? (_leaveOfAbsenceDetails = new LeaveOfAbsenceDetailsRepository(_context)); }
        }
        public Repository<LeaveOfAbsenceMaster> LeaveOfAbsenceMasterRepository
        {
            get { return _leaveOfAbsenceMaster ?? (_leaveOfAbsenceMaster = new LeaveOfAbsenceMasterRepository(_context)); }
        }
        public Repository<LeavePlan> LeavePlanRepository
        {
            get { return _leavePlanRepository ?? (_leavePlanRepository = new LeavePlanRepository(_context)); }
        }
        public Repository<LeaveType> LeaveTypeRepository
        {
            get { return _leaveTypeRepository ?? (_leaveTypeRepository = new LeaveTypeRepository(_context)); }
        }

        public Repository<LeavePlanRate> LeavePlanRateRepository
        {
            get { return _leavePlanRateRepository ?? (_leavePlanRateRepository = new LeavePlanRateRepository(_context)); }
        }

        public Repository<EmployeeDesignation> EmployeeDesignationRepository
        {
            get { return _employeeDesignationRepository ?? (_employeeDesignationRepository = new EmployeeDesignationRepository(_context)); }
        }
        public Repository<BankAccount> BankAccountRepository
        {
            get { return _bankAccountRepository ?? (_bankAccountRepository = new BankAccountRepository(_context)); }
        }
        public Repository<BankTransaction> BankTransactionRepository
        {
            get { return _bankTransactionRepository ?? (_bankTransactionRepository = new BankTransactionRepository(_context)); }
        }

        public Repository<Supplier> SupplierRepository
        {
            get { return _supplierRepository ?? (_supplierRepository = new SupplierRepository(_context)); }
        }

        public Repository<SupplierPayment> SupplierPaymentRepository
        {
            get { return _supplierPaymentRepository ?? (_supplierPaymentRepository = new SupplierPaymentRepository(_context)); }
        }
        public Repository<Test_Name> TestNameRepository
        {
            get { return _testNameRepository ?? (_testNameRepository = new TestNameRepository(_context)); }
        }
        public Repository<TEST_CATEGORY> TestCategoryRepository
        {
            get { return _testCategoryRepository ?? (_testCategoryRepository = new TestCategoryRepository(_context)); }
        }

        public Repository<DEPARTMENT> DepartmentRepository
        {
            get { return _departmentRepository ?? (_departmentRepository = new DepartmentRepository(_context)); }
        }
        public Repository<GL_ACCOUNT> GLAccountRepository
        {
            get { return _glAccountRepository ?? (_glAccountRepository = new GLAccountRepository(_context)); }
        }

        public Repository<DRUG> DrugRepository
        {
            get { return _drugRepository ?? (_drugRepository = new DrugRepository(_context)); }
        }


        public Repository<DRUG_MANUFACTURER> DrugMenufacturerRepository
        {
            get { return _drugMenufacturerRepository ?? (_drugMenufacturerRepository = new DrugMenufacturerRepository(_context)); }
        }


        public Repository<DURG_PRESENTATION_TYPE> DrugPresentationTypeRepository
        {
            get { return _drugPresentationtypeRepository ?? (_drugPresentationtypeRepository = new DrugPresentationTypeRepository(_context)); }
        }

        public Repository<MsDialysisAmountPurpose> MsDialysisAmountPurposeRepository
        {
            get { return _msDialysisAmountPurpose ?? (_msDialysisAmountPurpose = new MsDialysisAmountPurposeRepository(_context)); }
        }

        public Repository<DialysisPayment> DialysisPaymentRepository
        {
            get { return _dialysisPayment ?? (_dialysisPayment = new DialysisPaymentRepository(_context)); }
        }

        public Repository<PatientDialysis> PatientDialysisRepository
        {
            get { return _patientDialysis ?? (_patientDialysis = new PatientDialysisRepository(_context)); }
        }

        public Repository<PatientEnrollDialysis> PatientEnrollDialysisRepository
        {
            get { return _patientEnrollDialysis ?? (_patientEnrollDialysis = new PatientEnrollDialysisRepository(_context)); }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {





                    if (_context != null)
                    {
                        _context.Dispose();

                    }
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

    }
}