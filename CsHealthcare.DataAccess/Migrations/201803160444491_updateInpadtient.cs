namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInpadtient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationTheatres", "AdmissionNo", c => c.String());
            AddColumn("dbo.InPatientDailyBills", "AdmissionNo", c => c.String());
            AddColumn("dbo.InPatientDailyBills", "RecStatus", c => c.String());
            AddColumn("dbo.InPatientDailyBills", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.InPatientDailyBills", "CreatedBy", c => c.String());
            AddColumn("dbo.InPatientDailyBills", "ModifiedBy", c => c.String());
            AddColumn("dbo.InPatientDischarges", "AdmissionNo", c => c.String());
            AddColumn("dbo.InPatientDoctorInvoices", "AdmissionNo", c => c.String());
            AddColumn("dbo.InPatientDoctorInvoices", "RecStatus", c => c.String());
            AddColumn("dbo.InPatientDoctorInvoices", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.InPatientDoctorInvoices", "CreatedBy", c => c.String());
            AddColumn("dbo.InPatientDoctorInvoices", "ModifiedBy", c => c.String());
            AddColumn("dbo.InPatientDrugs", "AdmissionNo", c => c.String());
            AddColumn("dbo.InPatientDrugs", "RecStatus", c => c.String());
            AddColumn("dbo.InPatientDrugs", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.InPatientDrugs", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.InPatientDrugs", "CreatedBy", c => c.String());
            AddColumn("dbo.InPatientDrugs", "ModifiedBy", c => c.String());
            AddColumn("dbo.InPatientTests", "AdmissionNo", c => c.String());
            AddColumn("dbo.InPatientTests", "RecStatus", c => c.String());
            AddColumn("dbo.InPatientTests", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.InPatientTests", "CreatedBy", c => c.String());
            AddColumn("dbo.InPatientTests", "ModifiedBy", c => c.String());
            AddColumn("dbo.InPatientTransfers", "AdmissionNo", c => c.String());
            AddColumn("dbo.PatientAdmissions", "AdmissionNo", c => c.String());
            AddColumn("dbo.PatientAdmissions", "RecStatus", c => c.String());
            AddColumn("dbo.PatientLasers", "AdmissionNo", c => c.String());
            AddColumn("dbo.PatientLasers", "RecStatus", c => c.String());
            AddColumn("dbo.PatientLasers", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.PatientLasers", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientLasers", "ModifiedBy");
            DropColumn("dbo.PatientLasers", "ModifiedDate");
            DropColumn("dbo.PatientLasers", "RecStatus");
            DropColumn("dbo.PatientLasers", "AdmissionNo");
            DropColumn("dbo.PatientAdmissions", "RecStatus");
            DropColumn("dbo.PatientAdmissions", "AdmissionNo");
            DropColumn("dbo.InPatientTransfers", "AdmissionNo");
            DropColumn("dbo.InPatientTests", "ModifiedBy");
            DropColumn("dbo.InPatientTests", "CreatedBy");
            DropColumn("dbo.InPatientTests", "ModifiedDate");
            DropColumn("dbo.InPatientTests", "RecStatus");
            DropColumn("dbo.InPatientTests", "AdmissionNo");
            DropColumn("dbo.InPatientDrugs", "ModifiedBy");
            DropColumn("dbo.InPatientDrugs", "CreatedBy");
            DropColumn("dbo.InPatientDrugs", "ModifiedDate");
            DropColumn("dbo.InPatientDrugs", "CreatedDate");
            DropColumn("dbo.InPatientDrugs", "RecStatus");
            DropColumn("dbo.InPatientDrugs", "AdmissionNo");
            DropColumn("dbo.InPatientDoctorInvoices", "ModifiedBy");
            DropColumn("dbo.InPatientDoctorInvoices", "CreatedBy");
            DropColumn("dbo.InPatientDoctorInvoices", "ModifiedDate");
            DropColumn("dbo.InPatientDoctorInvoices", "RecStatus");
            DropColumn("dbo.InPatientDoctorInvoices", "AdmissionNo");
            DropColumn("dbo.InPatientDischarges", "AdmissionNo");
            DropColumn("dbo.InPatientDailyBills", "ModifiedBy");
            DropColumn("dbo.InPatientDailyBills", "CreatedBy");
            DropColumn("dbo.InPatientDailyBills", "ModifiedDate");
            DropColumn("dbo.InPatientDailyBills", "RecStatus");
            DropColumn("dbo.InPatientDailyBills", "AdmissionNo");
            DropColumn("dbo.OperationTheatres", "AdmissionNo");
        }
    }
}
