using System.Security.Policy;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Accounts;
using CsHealthcare.DataAccess.Entities.Doctor;
using CsHealthcare.DataAccess.Entities.Hospital;
using CsHealthcare.DataAccess.Entities.Operation;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Entity.Cabin;
using CsHealthcare.DataAccess.Entity.Canteen;
using CsHealthcare.DataAccess.Entity.Diagnostic;
using CsHealthcare.DataAccess.Entity.EmployeeLoan;
using CsHealthcare.DataAccess.Entity.Hospital;
//using CsHealthcare.DataAccess.Entity.EmployeeLoan;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.LabItem;
using CsHealthcare.DataAccess.Entity.LeaveManagement;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Entity.MicrobiologyTest;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Entity.Stock;
using CsHealthcare.DataAccess.Entity.Store;
using CsHealthcare.DataAccess.HumanResource;
using CsHealthcare.DataAccess.Dialysis;
using CsHealthcare.DataAccess.Entity.Ambulance;
using CsHealthcare.DataAccess.Entity.Packages;
using CsHealthcare.DataAccess.Entity.Physiotherapy;
using CsHealthcare.DataAccess.Entity.Views;

namespace CsHealthcare.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entity;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
            // this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<AppDbContext>(null);
        }
        public virtual DbSet<PatientAppointmentDialysis> PatientAppointmentDialysis { get; set; }

        public virtual DbSet<CheckInCheckOut> CheckInCheckOuts { get; set; }
        public virtual DbSet<AttendenceTemp> AttendenceTemps { get; set; }
        public virtual DbSet<EmployeeAttendenceCheckInOut> EmployeeAttendenceCheckInOuts { get; set; }
        public virtual DbSet<DoctorAttendenceCheckInOut> DoctorAttendenceCheckInOuts { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }

        public virtual DbSet<PatientEnrollDialysis> PatientEnrollDialysiss { get; set; }
        public virtual DbSet<DialysisPayment> DialysisPayments { get; set; }
        public virtual DbSet<PatientDialysis> PatientDialysis { get; set; }
        public virtual DbSet<MsDialysisAmountPurpose> MsDialysisAmountPurposes { get; set; }

        public virtual DbSet<TransactionRecord> TransactionRecords { get; set; }
        public virtual DbSet<TransDefination> TransDefinations { get; set; }

        public virtual DbSet<DrugsSelectedGroups> DrugsSelectedGroups { get; set; }
        public virtual DbSet<DrugInvoicePayment> DrugInvoicePayments { get; set; }
        public virtual DbSet<DrugDoseChart> DrugDoseCharts { get; set; }
        public virtual DbSet<DrugDailyStockHistory> DrugDailyStockHistories { get; set; }

        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<RentAmbulance> RentAmbulance { get; set; }
        public virtual DbSet<DrugSaleReturn> DrugSaleReturns { get; set; }
        public virtual DbSet<DrugSale> DrugSales { get; set; }
        public virtual DbSet<DrugSaleDetails> DrugSaleDetails { get; set; }
        public virtual DbSet<DrugSaleHistory> DrugSaleHistories { get; set; }
        public virtual DbSet<DrugSaleDetailsHistory> DrugSaleDetailsHistories { get; set; }



        public virtual DbSet<VisitDiscount> VisitDiscounts { get; set; }
        public virtual DbSet<PatientEnroll> PatientEnrolls { get; set; }
        public virtual DbSet<PatientFamilyDisease> PatientFamilyDiseases { get; set; }
        public virtual DbSet<PatientGeneralExam> PatientGeneralExams { get; set; }
        public virtual DbSet<PatientHistory> PatientHistories { get; set; }
        public virtual DbSet<PatientInvestigation> PatientInvestigations { get; set; }
        public virtual DbSet<PatientOldInvestigation> PatientOldInvestigations { get; set; }
        public virtual DbSet<PatientPastHistoryOfMadication> PatientPastHistoryOfMadications { get; set; }
        public virtual DbSet<PatientPastIllness> PatientPastIllness { get; set; }
        public virtual DbSet<PatientPersonalAttribute> PatientPersonalAttribute { get; set; }
        public virtual DbSet<PatientPersonalHistory> PatientPersonalHistories { get; set; }
        public virtual DbSet<PatientPersonalHistoryDetails> PatientPersonalHistoryDetails { get; set; }
        public virtual DbSet<PatientPrescription> PatientPrescriptions { get; set; }
        public virtual DbSet<PatientSpecialNote> PatientSpecialNotes { get; set; }
        public virtual DbSet<PatientTreatment> PatientTreatments { get; set; }
        public virtual DbSet<ReportScanCopy> ReportScanCopies { get; set; }

        public virtual DbSet<PatientEducation> PatientEducations { get; set; }

        public virtual DbSet<PatientCard> PatientCards { get; set; }
        public virtual DbSet<SpecialNote> SpecialNotes { get; set; }
        public virtual DbSet<SocialEconomicStatus> EconomicStatus { get; set; }

        public virtual DbSet<DrugDuration> DrugDurations { get; set; }
        public virtual DbSet<OperationNote> OperationNotes { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<FamilyTree> FamilyTrees { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<DiseaseCondition> DiseaseConditions { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }

        public virtual DbSet<MsAmountPurpose> MsAmountPurposes { get; set; }
        public virtual DbSet<DoctorNote> DoctorNotes { get; set; }
        public virtual DbSet<DoctorBusinessHour> DoctorBusinessHours { get; set; }
        public virtual DbSet<DoctorBusinessHoliday> DoctorBusinessHolidays { get; set; }
        public virtual DbSet<DoctorAppointmentPayment> DoctorAppointmentPayments { get; set; }
        public virtual DbSet<DoctorAppointment> DoctorAppointments { get; set; }

        public virtual DbSet<ChiefComplaint> ChiefComplaints { get; set; }
        public virtual DbSet<ChiefComplaintDuration> ChiefComplaintDurations { get; set; }
        public virtual DbSet<PatientChiefComplaint> PatientChiefComplaints { get; set; }

        public virtual DbSet<AllergyInformation> AllergyInformations { get; set; }
        public virtual DbSet<AllergySubstance> AllergySubstances { get; set; }
        public virtual DbSet<PatientAllergyInformation> PatientAllergyInformations { get; set; }

        public virtual DbSet<DoctorInformation> DoctorInformations { get; set; }
        public virtual DbSet<HospitalInformation> HospitalInformations { get; set; }

        public virtual DbSet<OperationType> OperationTypes { get; set; }
        public virtual DbSet<AppAppointmentSystemUser> AppAppointmentSystemUsers { get; set; }
        public virtual DbSet<AppMedicineCornerUser> AppMedicineCornerUsers { get; set; }
        public virtual DbSet<AppPatientManagementUser> AppPatientManagementUsers { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<APP_CONFIGURATION> AppConfiguration { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        /*MedicineCorner*/
        public virtual DbSet<DRUG> Drugs { get; set; }
        public virtual DbSet<DRUG_MANUFACTURER> DrugManufacturers { get; set; }
        public virtual DbSet<DURG_PRESENTATION_TYPE> DurgPresentationTypes { get; set; }
        public virtual DbSet<DrugDose> DrugDoses { get; set; }
        public virtual DbSet<DrugGroup> DrugGroups { get; set; }
        public virtual DbSet<InPatientDrugSaleReturn> InPatientDrugSaleReturns { get; set; }
        public virtual DbSet<InPatientDrugSaleReturnDetails> InPatientDrugSaleReturnDetails { get; set; }

        public virtual DbSet<DrugStockIn> DrugStockIns { get; set; }
        public virtual DbSet<DrugStockDetails> DrugStockDetails { get; set; }
        public virtual DbSet<StoreItem> StoreItems { get; set; }
        public virtual DbSet<StoreItemCategory> StoreItemCategories { get; set; }

        public virtual DbSet<StockIn> StockIns { get; set; }
        public virtual DbSet<StockInDetails> StockInDetails { get; set; }
        public virtual DbSet<StockOutItem> StockOutItems { get; set; }
        public virtual DbSet<StockOutDetails> StockOutDetails { get; set; }
        public virtual DbSet<ItemStockOut> ItemStockOut { get; set; }
        public virtual DbSet<ItemStockOutDetails> ItemStockOutDetails { get; set; }

        public virtual DbSet<StoreRequisition> StoreRequisitions { get; set; }
        public virtual DbSet<StoreRequisitionDetails> StoreRequisitionDetails { get; set; }

        public virtual DbSet<PharmacyRequisition> PharmacyRequisitions { get; set; }
        public virtual DbSet<PharmacyRequisitionDetails> PharmacyRequisitionDetails { get; set; }
        public virtual DbSet<DrugDepartmentWiseStockIn> DrugDepartmentWiseStockIn { get; set; }
        public virtual DbSet<DrugDepartmentWiseStockInDetails> DrugDepartmentWiseStockInDetails { get; set; }

        public virtual DbSet<DrugDepartmentWiseStockOut> DrugDepartmentWiseStockOuts { get; set; }
        public virtual DbSet<DrugDepartmentWiseStockOutDetails> DrugDepartmentWiseStockOutDetails { get; set; }

        /*HumanResource*/
        public virtual DbSet<DEPARTMENT> Departments { get; set; }
        public virtual DbSet<GL_ACCOUNT> GlAccounts { get; set; } 
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<BankTransaction> BankTransactions { get; set; }
        public virtual DbSet<DailyExpense> DailyExpenses { get; set; }
        public virtual DbSet<OccurrenceType> OccurrenceTypes { get; set; }
        public virtual DbSet<Occurrence> Occurrences { get; set; }
        public virtual DbSet<EmployeeDesignation> EmployeeDesignations { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }

        public virtual DbSet<TaxConfiguration> TaxConfigurations { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }

        public virtual DbSet<ShiftInfo> ShiftInfo { get; set; }

        public virtual DbSet<InsuranceCompany> InsuranceCompany { get; set; }
        public virtual DbSet<InsurancePlan> InsurancePlan { get; set; }
        public virtual DbSet<LC> Lc { get; set; }

        public virtual DbSet<GlTransaction> GlTransactions { get; set; }

        /*Account*/
        //public virtual DbSet<GL_ACCOUNT> GlAccounts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierPayment> SupplierPayments { get; set; }

        /*Diagnostic*/

        public virtual DbSet<TEST_CATEGORY> TestCategorys { get; set; }
        public virtual DbSet<Test_Name> TestNames { get; set; }

        public virtual DbSet<TestRequest> TestRequests { get; set; }
        public virtual DbSet<RETest> RETest { get; set; }
        public virtual DbSet<SRETest> SRETest { get; set; }

        public virtual DbSet<CBCTest> CBCTest { get; set; }

        public virtual DbSet<ENDOCRINOLOGY> ENDOCRINOLOGY { get; set; }
        public virtual DbSet<IMMUNOLOGICAL> IMMUNOLOGICAL { get; set; }

        public virtual DbSet<SEROLOGY> SEROLOGY { get; set; }
        public virtual DbSet<BioChemistry> BioChemistry { get; set; }

        /*LeaveManagement*/
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<LeavePlan> LeavePlans { get; set; }
        public virtual DbSet<LeavePlanRate> LeavePlanRates { get; set; }
        public virtual DbSet<LeaveOfAbsenceMaster> LeaveOfAbsenceMasters { get; set; }
        public virtual DbSet<LeaveOfAbsenceDetails> LeaveOfAbsenceDetails { get; set; }


        //Patient
        public virtual DbSet<PatientInformation> PatientInformations { get; set; }
        public virtual DbSet<PatientDetails> PatientDetails { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        //EmployeeLoan
        public virtual DbSet<LoanConfig> LoanConfigs { get; set; }
        public virtual DbSet<loanConfigPlan> loanConfigPlans { get; set; }
        public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; }


        /*Cabin*/
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<CabinType> CabinTypes { get; set; }
        public virtual DbSet<CabinAmenity> CabinAmenities { get; set; }
        public virtual DbSet<CabinRent> CabinRents { get; set; }

        public virtual DbSet<Amenity> Amenities { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<WardType> WardTypes { get; set; }
        public virtual DbSet<Bed> Beds { get; set; }
        public virtual DbSet<LabItem> LabItems { get; set; }


        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public virtual DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        //micobiologyTest
        public virtual DbSet<Specimen> Specimens { get; set; }
        public virtual DbSet<MicrobiologyTest> MicrobiologyTests { get; set; }


        public virtual DbSet<Purpose> Purposes { get; set; }
        public virtual DbSet<PatientAdmission> PatientAdmissions { get; set; }
        public virtual DbSet<PatientAdmissionDetails> PatientAdmissionDetails { get; set; }
        public virtual DbSet<PatientLaser> PatientLasers { get; set; }
        public virtual DbSet<InPatientDailyBill> InPatientDailyBills { get; set; }
        public virtual DbSet<InPatientDailyBillDetails> InPatientDailyBillDetails { get; set; }

        public virtual DbSet<InPatientDrug> InPatientDrugs { get; set; }
        public virtual DbSet<InPatientDrugDetails> InPatientDrugDetails { get; set; }
        public virtual DbSet<InPatientDischarge> InPatientDischarges { get; set; }
      
        public virtual DbSet<InPatientDoctorInvoice> InPatientDoctorInvoices { get; set; }


        public virtual DbSet<InPatientTest> InPatientTests { get; set; }
        public virtual DbSet<InPatientTestdetails> InPatientTestDetails { get; set; }


        public virtual DbSet<OptPatientBill> OptPatientBills { get; set; }
        public virtual DbSet<OptPatientBillDetails> OptPatientBillDetails { get; set; }
        public virtual DbSet<OpdPatientDuebillCollection> OpdPatientDuebillCollections { get; set; }

        //Canteen
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }


        public virtual DbSet<Category> Categories{ get; set; }
        public virtual DbSet<Sells> Sells { get; set; }
        public virtual DbSet<SellsDetails> SellsDetails { get; set; }
        public virtual DbSet<CanteenFoodInPatient> CanteenFoodInPatients { get; set; }
        public virtual DbSet<CanteenFoodInPatientDetails> CanteenFoodInPatientDetails { get; set; }



        //Package
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageDetails> PackageDetails { get; set; }
        public virtual DbSet<PackageExcludes> PackageExcludes { get; set; }
        public virtual DbSet<PackageForCheckUp> PackageForCheckUps { get; set; }
        public virtual DbSet<PackageForCheckupDetails> PackageForCheckupDetails { get; set; }
        public virtual DbSet<BillingForCheckupPackage> BillingForCheckupPackage { get; set; }
        public virtual DbSet<BillingForCheckupPackageDetails> BillingForCheckupPackageDetails { get; set; }
        public virtual DbSet<Physiotherapy> Physiotherapies { get; set; }
        public virtual DbSet<OPDTherapy> OPDTherapy { get; set; }
        public virtual DbSet<OpdTherapyDetails> OpdTherapyDetails { get; set; }
        public virtual DbSet<OpdTherapyDueCollection> OpdTherapyDueCollections { get; set; }
        public virtual DbSet<ICU> ICU { get; set; }
        public virtual DbSet<ICUBeds> ICUBeds { get; set; }
        public virtual DbSet<ICURent> ICURents { get; set; }
        public virtual DbSet<InPatientTransfer> InPatientTransfers { get; set; }
        public virtual DbSet<InPatientTransferBack> InPatientTransferBack { get; set; }

        public virtual DbSet<InPatientDischargeSummary> InPatientDischargeSummaries { get; set; }

        public virtual DbSet<PrescriptionAttatchment> PrescriptionAttatchments { get; set; }
        public virtual DbSet<PatientTestReportAttatchment> PatientTestReportAttatchments { get; set; }



        public virtual DbSet<OperationTheatre> OperationTheatre { get; set; }
        public virtual DbSet<SurgeonName> SurgeonNames { get; set; }
        public virtual DbSet<PurposeOnOT> PurposeOnOT { get; set; }
        public virtual DbSet<Anesthesia> Anesthesia { get; set; }
        public virtual DbSet<AssistantDoctor> AssistantDoctors { get; set; }
        public virtual DbSet<PatientDueCollection> PatientDueCollections { get; set; }
        public virtual DbSet<CabinToCabinTransfer> CabinToCabinTransfers { get; set; }
        public virtual DbSet<CabinTransferBack> CabinTransferBacks { get; set; }
        public virtual DbSet<MerketingBy> MerketingBy { get; set; }

        #region Views

        public virtual DbSet<VDrugs> VDrugses { get; set; }
        public virtual DbSet<VW_DRUG_CONDITION> VW_DRUG_CONDITION { get; set; }
        public virtual DbSet<VW_DRUG_SALE_ALL> VW_DRUG_SALE_ALL { get; set; }
        public virtual DbSet<VW_IPD_DRUG_SALE> VW_IPD_DRUG_SALE { get; set; }
        public virtual DbSet<VW_IPD_DRUG_SALE_RETURN> VW_IPD_DRUG_SALE_RETURN { get; set; }
        public virtual DbSet<VW_IPD_DRUG_SALE_TOTAL> VW_IPD_DRUG_SALE_TOTAL { get; set; }
        public virtual DbSet<VW_DRUG_AVILABLE_STOCK> VW_DRUG_AVILABLE_STOCK { get; set; }
        public virtual DbSet<VW_DRUG_STOCK> VwDrugStocks { get; set; }
        public virtual DbSet<VW_Department1_Wise_DRUG_STOCK> VW_Department1_Wise_DRUG_STOCK { get; set; }
 public virtual DbSet<VW_DAILY_USER_COLLECTION> VW_DAILY_USER_COLLECTION { get; set; }
        #endregion

        public virtual DbSet<IpdDraft> IpdDrafts { get; set; }

        public virtual DbSet<InPatientDischargeDueCollection> InPatientDischargeDueCollections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            /*MedicineCorner*/
            modelBuilder.Entity<DRUG_MANUFACTURER>()
           .HasMany(e => e.DRUGS)
           .WithRequired(e => e.DRUG_MANUFACTURER)
           .HasForeignKey(e => e.D_DM_ID)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<DURG_PRESENTATION_TYPE>()
           .HasMany(e => e.DRUGS)
           .WithRequired(e => e.DURG_PRESENTATION_TYPE)
           .HasForeignKey(e => e.D_DPT_ID)
           .WillCascadeOnDelete(false);


            modelBuilder.Entity<TEST_CATEGORY>()
               .HasMany(e => e.TestNames)
               .WithOptional(e => e.TEST_CATEGORY)
               .HasForeignKey(e => e.T_TC_ID);

           


            modelBuilder.Entity<DrugStockIn>()
              .HasMany(e => e.DrugStockDetails)
              .WithRequired(e => e.DrugStockIn)
              .HasForeignKey(e => e.DrugStockInId)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<InPatientDrugSaleReturn>()
             .HasMany(e => e.InPatientDrugSaleReturnDetails)
             .WithRequired(e => e.InPatientDrugSaleReturn)
             .HasForeignKey(e => e.InPatientDrugSaleReturnId)
             .WillCascadeOnDelete(false);


            modelBuilder.Entity<DrugDepartmentWiseStockIn>()
             .HasMany(e => e.DrugDepartmentWiseStockInDetails)
             .WithRequired(e => e.DrugDepartmentWiseStockIn)
             .HasForeignKey(e => e.DrugDepartmentWiseStockInId)
             .WillCascadeOnDelete(false);



            modelBuilder.Entity<DrugSale>()
             .HasMany(e => e.DrugSaleDetails)
             .WithRequired(e => e.DrugSale)
             .HasForeignKey(e => e.DrugSaleId)
             .WillCascadeOnDelete(false);


            modelBuilder.Entity<DrugDepartmentWiseStockOut>()
            .HasMany(e => e.DrugDepartmentWiseStockOutDetails)
            .WithRequired(e => e.DrugDepartmentWiseStockOut)
            .HasForeignKey(e => e.DrugDepartmentWiseStockOutId)
            .WillCascadeOnDelete(false);


            modelBuilder.Entity<ICU>()
           .HasMany(e => e.ICUBeds)
           .WithRequired(e => e.Icu)
           .HasForeignKey(e => e.IcuId)
           .WillCascadeOnDelete(false);


            modelBuilder.Entity<DrugSaleHistory>()
            .HasMany(e => e.DrugSaleDetailsHistory)
            .WithRequired(e => e.DrugSaleHistory)
            .HasForeignKey(e => e.DrugSaleHistoryId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrder>()
            .HasMany(e => e.PurchaseOrderDetails)
            .WithRequired(e => e.PurchaseOrder)
            .HasForeignKey(e => e.PurchaseOrderId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
            .HasMany(e => e.PackageDetailses)
            .WithRequired(e => e.Package)
            .HasForeignKey(e => e.PackageId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
           .HasMany(e => e.PackageExcludes)
           .WithRequired(e => e.Package)
           .HasForeignKey(e => e.PackageId)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<InPatientDailyBill>()
           .HasMany(e => e.InPatientDailyBillDetails)
           .WithRequired(e => e.InPatientDailyBill)
           .HasForeignKey(e => e.InPatientDailyBillId)
           .WillCascadeOnDelete(false);



            modelBuilder.Entity<InPatientDrug>()
          .HasMany(e => e.InPatientDrugDetails)
          .WithRequired(e => e.InPatientDrug)
          .HasForeignKey(e => e.InPatientDrugId)
          .WillCascadeOnDelete(false);


            modelBuilder.Entity<InPatientTest>()
            .HasMany(e => e.InPatientTestDetails)
            .WithRequired(e => e.InPatientTest)
            .HasForeignKey(e => e.InPatientTestId)
            .WillCascadeOnDelete(false);




            modelBuilder.Entity<OptPatientBill>()
           .HasMany(e => e.OptPatientBillDetails)
           .WithRequired(e => e.OptPatientBill)
           .HasForeignKey(e => e.OptPatientBillId)
           .WillCascadeOnDelete(false);


            modelBuilder.Entity<OPDTherapy>()
          .HasMany(e => e.OpdTherapyDetails)
          .WithRequired(e => e.OpdTherapy)
          .HasForeignKey(e => e.OPDTherapyId)
          .WillCascadeOnDelete(false);


            modelBuilder.Entity<OccurrenceType>()
          .HasMany(e => e.Occurrences)
          .WithRequired(e => e.OccurrenceTypes)
          .HasForeignKey(e => e.OccurrenceTypeId)
          .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoanConfig>()
        .HasMany(e => e.loanConfigPlans)
        .WithRequired(e => e.LoanConfig)
        .HasForeignKey(e => e.LoanConfigId)
        .WillCascadeOnDelete(false);


            modelBuilder.Entity<AllergySubstance>()
           .HasMany(e => e.PatientAllergyInformations)
           .WithRequired(e => e.AllergySubstance)
           .HasForeignKey(e => e.AllergySubstanceId)
           .WillCascadeOnDelete(false);


            modelBuilder.Entity<DoctorInformation>()
           .HasMany(e => e.PatientHistories)
           .WithRequired(e => e.DoctorInformation)
           .HasForeignKey(e => e.DoctorId)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientInformation>()
           .HasMany(e => e.PatientHistories)
           .WithRequired(e => e.PatientInformation)
           .HasForeignKey(e => e.PatientId)
           .WillCascadeOnDelete(false);


            modelBuilder.Entity<OperationTheatre>()
          .HasMany(e => e.SurgeonName)
          .WithRequired(e => e.OperationTheatre)
          .HasForeignKey(e => e.OperationTheatreId)
          .WillCascadeOnDelete(false);


            modelBuilder.Entity<OperationTheatre>()
         .HasMany(e => e.PurposeOnOT)
         .WithRequired(e => e.OperationTheatre)
         .HasForeignKey(e => e.OperationTheatreId)
         .WillCascadeOnDelete(false);



            modelBuilder.Entity<OperationTheatre>()
        .HasMany(e => e.Anesthesia)
        .WithRequired(e => e.OperationTheatre)
        .HasForeignKey(e => e.OperationTheatreId)
        .WillCascadeOnDelete(false);

            modelBuilder.Entity<OperationTheatre>()
       .HasMany(e => e.AssistantDoctor)
       .WithRequired(e => e.OperationTheatre)
       .HasForeignKey(e => e.OperationTheatreId)
       .WillCascadeOnDelete(false);


            modelBuilder.Entity<InsuranceCompany>()
        
            .HasMany(e => e.Insurance)
            .WithRequired(e => e.InsuranceCompany)
            .HasForeignKey(e => e.InsuranceCompanyId)
            .WillCascadeOnDelete(false);


            modelBuilder.Entity<PatientPersonalAttribute>()
          .HasMany(e => e.PatientPersonalHistoryDetails)
          .WithRequired(e => e.PatientPersonalAttribute)
          .HasForeignKey(e => e.PatientPersonalAttributeId)
          .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientPersonalHistory>()
          .HasMany(e => e.PatientPersonalHistoryDetails)
          .WithRequired(e => e.PatientPersonalHistory)
          .HasForeignKey(e => e.PatientPersonalHistoryId)
          .WillCascadeOnDelete(false);



            modelBuilder.Entity<MsDialysisAmountPurpose>()
         .HasMany(e => e.DialysisPayments)
         .WithRequired(e => e.MsDialysisAmountPurpose)
         .HasForeignKey(e => e.MsDialysisAmountPurposeId)
         .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientEnrollDialysis>()
         .HasMany(e => e.DialysisPayments)
         .WithRequired(e => e.PatientEnrollDialysis)
         .HasForeignKey(e => e.PatientDialysisEnrollId)
         .WillCascadeOnDelete(false);


            modelBuilder.Entity<PatientInformation>()
         .HasMany(e => e.PatientDialysis)
         .WithRequired(e => e.PatientInformation)
         .HasForeignKey(e => e.PatientId)
         .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientInformation>()
        .HasMany(e => e.PatientDialysis)
        .WithRequired(e => e.PatientInformation)
        .HasForeignKey(e => e.PatientId)
        .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientInformation>()
        .HasMany(e => e.PatientEnrollDialysiss)
        .WithRequired(e => e.PatientInformation)
        .HasForeignKey(e => e.PatientId)
        .WillCascadeOnDelete(false);


            modelBuilder.Entity<Shift>()
       .HasMany(e => e.EmployeeInfos)
       .WithRequired(e => e.Shifts)
       .HasForeignKey(e => e.ShiftId)
       .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shift>()
       .HasMany(e => e.DoctorInformations)
       .WithRequired(e => e.Shifts)
       .HasForeignKey(e => e.ShiftId)
       .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeInfo>()
       .HasMany(e => e.CheckInCheckOuts)
       .WithRequired(e => e.EmployeeInfo)
       .HasForeignKey(e => e.EmployeeId)
       .WillCascadeOnDelete(false);

            modelBuilder.Entity<PatientInformation>()
       .HasMany(e => e.PatientAppointmentDialysis)
       .WithRequired(e => e.PatientInformation)
       .HasForeignKey(e => e.PatientId)
       .WillCascadeOnDelete(false);

        }
    }
}
