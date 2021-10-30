namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuditLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllergyInformations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.AllergyInformations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.AllergySubstances", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.AllergySubstances", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientAllergyInformations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientAllergyInformations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Cabins", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Cabins", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.CabinRents", "AdmissionNo", c => c.String(nullable: false));
            AddColumn("dbo.CabinRents", "PatientCode", c => c.String());
            AddColumn("dbo.CabinRents", "DischargeDate", c => c.DateTime());
            AddColumn("dbo.CabinRents", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.CabinRents", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientInformations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientInformations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DoctorAppointments", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DoctorAppointments", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DoctorInformations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DoctorInformations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.AppPatientManagementUsers", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.AppPatientManagementUsers", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.CheckInCheckOuts", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.CheckInCheckOuts", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DEPARTMENTs", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DEPARTMENTs", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Educations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Educations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Shifts", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Shifts", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.HospitalInformations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.HospitalInformations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.AppAppointmentSystemUsers", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.AppAppointmentSystemUsers", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.AppMedicineCornerUsers", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.AppMedicineCornerUsers", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.AppUsers", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.AppUsers", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DoctorBusinessHolidays", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DoctorBusinessHolidays", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DoctorBusinessHours", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DoctorBusinessHours", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.MsAmountPurposes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.MsAmountPurposes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DoctorAppointmentPayments", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DoctorAppointmentPayments", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientEnrolls", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientEnrolls", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.OperationNotes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.OperationNotes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientPrescriptions", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientPrescriptions", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientHistories", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientHistories", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientChiefComplaints", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientChiefComplaints", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.ChiefComplaints", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.ChiefComplaints", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.ChiefComplaintDurations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.ChiefComplaintDurations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientFamilyDiseases", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientFamilyDiseases", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Diseases", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Diseases", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientPastIllnesses", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientPastIllnesses", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DiseaseConditions", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DiseaseConditions", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.FamilyTrees", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.FamilyTrees", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientGeneralExams", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientGeneralExams", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientPastHistoryOfMadications", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientPastHistoryOfMadications", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DRUG", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DRUG", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DRUG_MANUFACTURER", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DRUG_MANUFACTURER", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugDoseCharts", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugDoseCharts", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugsSelectedGroups", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugsSelectedGroups", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugGroups", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugGroups", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DURG_PRESENTATION_TYPE", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DURG_PRESENTATION_TYPE", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientPersonalHistories", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientPersonalHistories", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientPersonalHistoryDetails", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientPersonalHistoryDetails", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientPersonalAttributes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientPersonalAttributes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientInvestigations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientInvestigations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Test_Name", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Test_Name", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.TEST_CATEGORY", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.TEST_CATEGORY", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientSpecialNotes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientSpecialNotes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientTreatments", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientTreatments", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DoctorNotes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DoctorNotes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugDurations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugDurations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.ReportScanCopies", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.ReportScanCopies", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.VisitDiscounts", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.VisitDiscounts", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugSales", "PatientName", c => c.String(maxLength: 250));
            AddColumn("dbo.DrugSales", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugSales", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Occupations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Occupations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientAppointmentDialysis", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientAppointmentDialysis", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientDetails", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientDetails", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Patients", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Patients", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientDialysis", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientDialysis", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientEnrollDialysis", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientEnrollDialysis", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DialysisPayments", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DialysisPayments", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.MsDialysisAmountPurposes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.MsDialysisAmountPurposes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientOldInvestigations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientOldInvestigations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.CabinTypes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.CabinTypes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DailyExpenses", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DailyExpenses", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugDailyStockHistories", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugDailyStockHistories", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugInvoicePayments", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugInvoicePayments", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugSaleReturns", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugSaleReturns", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.EmergencyContacts", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.EmergencyContacts", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.GlTransactions", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.GlTransactions", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Holidays", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Holidays", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDailyBills", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDailyBills", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDischarges", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDischarges", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDoctorInvoices", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDoctorInvoices", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDrugs", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.InPatientDrugs", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.InPatientTests", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.InPatientTests", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.InsuranceCompanies", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.InsuranceCompanies", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.InsurancePlans", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.InsurancePlans", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.IpdDrafts", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.IpdDrafts", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.LCs", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.LCs", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.LeaveOfAbsenceMasters", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.LeaveOfAbsenceMasters", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.LoanConfigs", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.LoanConfigs", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Occurrences", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Occurrences", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.OccurrenceTypes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.OccurrenceTypes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientAdmissions", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientAdmissions", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientLasers", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientLasers", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.RentAmbulances", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.RentAmbulances", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.ShiftInfoes", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.ShiftInfoes", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.StockIns", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.StockIns", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.StoreItems", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.StoreItems", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.SupplierPayments", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.SupplierPayments", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.Suppliers", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Suppliers", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.TaxConfigurations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.TaxConfigurations", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.TransactionRecords", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.TransactionRecords", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.TransDefinations", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.TransDefinations", "ModifiedIpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransDefinations", "ModifiedIpAddress");
            DropColumn("dbo.TransDefinations", "CreatedIpAddress");
            DropColumn("dbo.TransactionRecords", "ModifiedIpAddress");
            DropColumn("dbo.TransactionRecords", "CreatedIpAddress");
            DropColumn("dbo.TaxConfigurations", "ModifiedIpAddress");
            DropColumn("dbo.TaxConfigurations", "CreatedIpAddress");
            DropColumn("dbo.Suppliers", "ModifiedIpAddress");
            DropColumn("dbo.Suppliers", "CreatedIpAddress");
            DropColumn("dbo.SupplierPayments", "ModifiedIpAddress");
            DropColumn("dbo.SupplierPayments", "CreatedIpAddress");
            DropColumn("dbo.StoreItems", "ModifiedIpAddress");
            DropColumn("dbo.StoreItems", "CreatedIpAddress");
            DropColumn("dbo.StockIns", "ModifiedIpAddress");
            DropColumn("dbo.StockIns", "CreatedIpAddress");
            DropColumn("dbo.ShiftInfoes", "ModifiedIpAddress");
            DropColumn("dbo.ShiftInfoes", "CreatedIpAddress");
            DropColumn("dbo.RentAmbulances", "ModifiedIpAddress");
            DropColumn("dbo.RentAmbulances", "CreatedIpAddress");
            DropColumn("dbo.PatientLasers", "ModifiedIpAddress");
            DropColumn("dbo.PatientLasers", "CreatedIpAddress");
            DropColumn("dbo.PatientAdmissions", "ModifiedIpAddress");
            DropColumn("dbo.PatientAdmissions", "CreatedIpAddress");
            DropColumn("dbo.OccurrenceTypes", "ModifiedIpAddress");
            DropColumn("dbo.OccurrenceTypes", "CreatedIpAddress");
            DropColumn("dbo.Occurrences", "ModifiedIpAddress");
            DropColumn("dbo.Occurrences", "CreatedIpAddress");
            DropColumn("dbo.LoanConfigs", "ModifiedIpAddress");
            DropColumn("dbo.LoanConfigs", "CreatedIpAddress");
            DropColumn("dbo.LeaveOfAbsenceMasters", "ModifiedIpAddress");
            DropColumn("dbo.LeaveOfAbsenceMasters", "CreatedIpAddress");
            DropColumn("dbo.LCs", "ModifiedIpAddress");
            DropColumn("dbo.LCs", "CreatedIpAddress");
            DropColumn("dbo.IpdDrafts", "ModifiedIpAddress");
            DropColumn("dbo.IpdDrafts", "CreatedIpAddress");
            DropColumn("dbo.InsurancePlans", "ModifiedIpAddress");
            DropColumn("dbo.InsurancePlans", "CreatedIpAddress");
            DropColumn("dbo.InsuranceCompanies", "ModifiedIpAddress");
            DropColumn("dbo.InsuranceCompanies", "CreatedIpAddress");
            DropColumn("dbo.InPatientTests", "ModifiedIpAddress");
            DropColumn("dbo.InPatientTests", "CreatedIpAddress");
            DropColumn("dbo.InPatientDrugs", "ModifiedIpAddress");
            DropColumn("dbo.InPatientDrugs", "CreatedIpAddress");
            DropColumn("dbo.InPatientDoctorInvoices", "ModifiedIpAddress");
            DropColumn("dbo.InPatientDoctorInvoices", "CreatedIpAddress");
            DropColumn("dbo.InPatientDischarges", "ModifiedIpAddress");
            DropColumn("dbo.InPatientDischarges", "CreatedIpAddress");
            DropColumn("dbo.InPatientDailyBills", "ModifiedIpAddress");
            DropColumn("dbo.InPatientDailyBills", "CreatedIpAddress");
            DropColumn("dbo.Holidays", "ModifiedIpAddress");
            DropColumn("dbo.Holidays", "CreatedIpAddress");
            DropColumn("dbo.GlTransactions", "ModifiedIpAddress");
            DropColumn("dbo.GlTransactions", "CreatedIpAddress");
            DropColumn("dbo.EmergencyContacts", "ModifiedIpAddress");
            DropColumn("dbo.EmergencyContacts", "CreatedIpAddress");
            DropColumn("dbo.DrugSaleReturns", "ModifiedIpAddress");
            DropColumn("dbo.DrugSaleReturns", "CreatedIpAddress");
            DropColumn("dbo.DrugInvoicePayments", "ModifiedIpAddress");
            DropColumn("dbo.DrugInvoicePayments", "CreatedIpAddress");
            DropColumn("dbo.DrugDailyStockHistories", "ModifiedIpAddress");
            DropColumn("dbo.DrugDailyStockHistories", "CreatedIpAddress");
            DropColumn("dbo.DailyExpenses", "ModifiedIpAddress");
            DropColumn("dbo.DailyExpenses", "CreatedIpAddress");
            DropColumn("dbo.CabinTypes", "ModifiedIpAddress");
            DropColumn("dbo.CabinTypes", "CreatedIpAddress");
            DropColumn("dbo.PatientOldInvestigations", "ModifiedIpAddress");
            DropColumn("dbo.PatientOldInvestigations", "CreatedIpAddress");
            DropColumn("dbo.MsDialysisAmountPurposes", "ModifiedIpAddress");
            DropColumn("dbo.MsDialysisAmountPurposes", "CreatedIpAddress");
            DropColumn("dbo.DialysisPayments", "ModifiedIpAddress");
            DropColumn("dbo.DialysisPayments", "CreatedIpAddress");
            DropColumn("dbo.PatientEnrollDialysis", "ModifiedIpAddress");
            DropColumn("dbo.PatientEnrollDialysis", "CreatedIpAddress");
            DropColumn("dbo.PatientDialysis", "ModifiedIpAddress");
            DropColumn("dbo.PatientDialysis", "CreatedIpAddress");
            DropColumn("dbo.Patients", "ModifiedIpAddress");
            DropColumn("dbo.Patients", "CreatedIpAddress");
            DropColumn("dbo.PatientDetails", "ModifiedIpAddress");
            DropColumn("dbo.PatientDetails", "CreatedIpAddress");
            DropColumn("dbo.PatientAppointmentDialysis", "ModifiedIpAddress");
            DropColumn("dbo.PatientAppointmentDialysis", "CreatedIpAddress");
            DropColumn("dbo.Occupations", "ModifiedIpAddress");
            DropColumn("dbo.Occupations", "CreatedIpAddress");
            DropColumn("dbo.DrugSales", "ModifiedIpAddress");
            DropColumn("dbo.DrugSales", "CreatedIpAddress");
            DropColumn("dbo.DrugSales", "PatientName");
            DropColumn("dbo.VisitDiscounts", "ModifiedIpAddress");
            DropColumn("dbo.VisitDiscounts", "CreatedIpAddress");
            DropColumn("dbo.ReportScanCopies", "ModifiedIpAddress");
            DropColumn("dbo.ReportScanCopies", "CreatedIpAddress");
            DropColumn("dbo.DrugDurations", "ModifiedIpAddress");
            DropColumn("dbo.DrugDurations", "CreatedIpAddress");
            DropColumn("dbo.DoctorNotes", "ModifiedIpAddress");
            DropColumn("dbo.DoctorNotes", "CreatedIpAddress");
            DropColumn("dbo.PatientTreatments", "ModifiedIpAddress");
            DropColumn("dbo.PatientTreatments", "CreatedIpAddress");
            DropColumn("dbo.PatientSpecialNotes", "ModifiedIpAddress");
            DropColumn("dbo.PatientSpecialNotes", "CreatedIpAddress");
            DropColumn("dbo.TEST_CATEGORY", "ModifiedIpAddress");
            DropColumn("dbo.TEST_CATEGORY", "CreatedIpAddress");
            DropColumn("dbo.Test_Name", "ModifiedIpAddress");
            DropColumn("dbo.Test_Name", "CreatedIpAddress");
            DropColumn("dbo.PatientInvestigations", "ModifiedIpAddress");
            DropColumn("dbo.PatientInvestigations", "CreatedIpAddress");
            DropColumn("dbo.PatientPersonalAttributes", "ModifiedIpAddress");
            DropColumn("dbo.PatientPersonalAttributes", "CreatedIpAddress");
            DropColumn("dbo.PatientPersonalHistoryDetails", "ModifiedIpAddress");
            DropColumn("dbo.PatientPersonalHistoryDetails", "CreatedIpAddress");
            DropColumn("dbo.PatientPersonalHistories", "ModifiedIpAddress");
            DropColumn("dbo.PatientPersonalHistories", "CreatedIpAddress");
            DropColumn("dbo.DURG_PRESENTATION_TYPE", "ModifiedIpAddress");
            DropColumn("dbo.DURG_PRESENTATION_TYPE", "CreatedIpAddress");
            DropColumn("dbo.DrugGroups", "ModifiedIpAddress");
            DropColumn("dbo.DrugGroups", "CreatedIpAddress");
            DropColumn("dbo.DrugsSelectedGroups", "ModifiedIpAddress");
            DropColumn("dbo.DrugsSelectedGroups", "CreatedIpAddress");
            DropColumn("dbo.DrugDoseCharts", "ModifiedIpAddress");
            DropColumn("dbo.DrugDoseCharts", "CreatedIpAddress");
            DropColumn("dbo.DRUG_MANUFACTURER", "ModifiedIpAddress");
            DropColumn("dbo.DRUG_MANUFACTURER", "CreatedIpAddress");
            DropColumn("dbo.DRUG", "ModifiedIpAddress");
            DropColumn("dbo.DRUG", "CreatedIpAddress");
            DropColumn("dbo.PatientPastHistoryOfMadications", "ModifiedIpAddress");
            DropColumn("dbo.PatientPastHistoryOfMadications", "CreatedIpAddress");
            DropColumn("dbo.PatientGeneralExams", "ModifiedIpAddress");
            DropColumn("dbo.PatientGeneralExams", "CreatedIpAddress");
            DropColumn("dbo.FamilyTrees", "ModifiedIpAddress");
            DropColumn("dbo.FamilyTrees", "CreatedIpAddress");
            DropColumn("dbo.DiseaseConditions", "ModifiedIpAddress");
            DropColumn("dbo.DiseaseConditions", "CreatedIpAddress");
            DropColumn("dbo.PatientPastIllnesses", "ModifiedIpAddress");
            DropColumn("dbo.PatientPastIllnesses", "CreatedIpAddress");
            DropColumn("dbo.Diseases", "ModifiedIpAddress");
            DropColumn("dbo.Diseases", "CreatedIpAddress");
            DropColumn("dbo.PatientFamilyDiseases", "ModifiedIpAddress");
            DropColumn("dbo.PatientFamilyDiseases", "CreatedIpAddress");
            DropColumn("dbo.ChiefComplaintDurations", "ModifiedIpAddress");
            DropColumn("dbo.ChiefComplaintDurations", "CreatedIpAddress");
            DropColumn("dbo.ChiefComplaints", "ModifiedIpAddress");
            DropColumn("dbo.ChiefComplaints", "CreatedIpAddress");
            DropColumn("dbo.PatientChiefComplaints", "ModifiedIpAddress");
            DropColumn("dbo.PatientChiefComplaints", "CreatedIpAddress");
            DropColumn("dbo.PatientHistories", "ModifiedIpAddress");
            DropColumn("dbo.PatientHistories", "CreatedIpAddress");
            DropColumn("dbo.PatientPrescriptions", "ModifiedIpAddress");
            DropColumn("dbo.PatientPrescriptions", "CreatedIpAddress");
            DropColumn("dbo.OperationNotes", "ModifiedIpAddress");
            DropColumn("dbo.OperationNotes", "CreatedIpAddress");
            DropColumn("dbo.PatientEnrolls", "ModifiedIpAddress");
            DropColumn("dbo.PatientEnrolls", "CreatedIpAddress");
            DropColumn("dbo.DoctorAppointmentPayments", "ModifiedIpAddress");
            DropColumn("dbo.DoctorAppointmentPayments", "CreatedIpAddress");
            DropColumn("dbo.MsAmountPurposes", "ModifiedIpAddress");
            DropColumn("dbo.MsAmountPurposes", "CreatedIpAddress");
            DropColumn("dbo.DoctorBusinessHours", "ModifiedIpAddress");
            DropColumn("dbo.DoctorBusinessHours", "CreatedIpAddress");
            DropColumn("dbo.DoctorBusinessHolidays", "ModifiedIpAddress");
            DropColumn("dbo.DoctorBusinessHolidays", "CreatedIpAddress");
            DropColumn("dbo.AppUsers", "ModifiedIpAddress");
            DropColumn("dbo.AppUsers", "CreatedIpAddress");
            DropColumn("dbo.AppMedicineCornerUsers", "ModifiedIpAddress");
            DropColumn("dbo.AppMedicineCornerUsers", "CreatedIpAddress");
            DropColumn("dbo.AppAppointmentSystemUsers", "ModifiedIpAddress");
            DropColumn("dbo.AppAppointmentSystemUsers", "CreatedIpAddress");
            DropColumn("dbo.HospitalInformations", "ModifiedIpAddress");
            DropColumn("dbo.HospitalInformations", "CreatedIpAddress");
            DropColumn("dbo.Shifts", "ModifiedIpAddress");
            DropColumn("dbo.Shifts", "CreatedIpAddress");
            DropColumn("dbo.Educations", "ModifiedIpAddress");
            DropColumn("dbo.Educations", "CreatedIpAddress");
            DropColumn("dbo.DEPARTMENTs", "ModifiedIpAddress");
            DropColumn("dbo.DEPARTMENTs", "CreatedIpAddress");
            DropColumn("dbo.CheckInCheckOuts", "ModifiedIpAddress");
            DropColumn("dbo.CheckInCheckOuts", "CreatedIpAddress");
            DropColumn("dbo.EmployeeInfoes", "ModifiedIpAddress");
            DropColumn("dbo.EmployeeInfoes", "CreatedIpAddress");
            DropColumn("dbo.AppPatientManagementUsers", "ModifiedIpAddress");
            DropColumn("dbo.AppPatientManagementUsers", "CreatedIpAddress");
            DropColumn("dbo.DoctorInformations", "ModifiedIpAddress");
            DropColumn("dbo.DoctorInformations", "CreatedIpAddress");
            DropColumn("dbo.DoctorAppointments", "ModifiedIpAddress");
            DropColumn("dbo.DoctorAppointments", "CreatedIpAddress");
            DropColumn("dbo.PatientInformations", "ModifiedIpAddress");
            DropColumn("dbo.PatientInformations", "CreatedIpAddress");
            DropColumn("dbo.CabinRents", "ModifiedIpAddress");
            DropColumn("dbo.CabinRents", "CreatedIpAddress");
            DropColumn("dbo.CabinRents", "DischargeDate");
            DropColumn("dbo.CabinRents", "PatientCode");
            DropColumn("dbo.CabinRents", "AdmissionNo");
            DropColumn("dbo.Cabins", "ModifiedIpAddress");
            DropColumn("dbo.Cabins", "CreatedIpAddress");
            DropColumn("dbo.PatientAllergyInformations", "ModifiedIpAddress");
            DropColumn("dbo.PatientAllergyInformations", "CreatedIpAddress");
            DropColumn("dbo.AllergySubstances", "ModifiedIpAddress");
            DropColumn("dbo.AllergySubstances", "CreatedIpAddress");
            DropColumn("dbo.AllergyInformations", "ModifiedIpAddress");
            DropColumn("dbo.AllergyInformations", "CreatedIpAddress");
        }
    }
}