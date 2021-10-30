namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remarks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientInformations", "Remarks", c => c.String(maxLength: 200));
            AddColumn("dbo.BillingForCheckupPackages", "Remarks", c => c.String(maxLength: 200));
            AddColumn("dbo.InPatientDailyBills", "Remarks", c => c.String(maxLength: 200));
            AddColumn("dbo.InPatientDischarges", "Remarks", c => c.String(maxLength: 200));
            AddColumn("dbo.InPatientDrugs", "Remarks", c => c.String(maxLength: 200));
            AddColumn("dbo.OPDTherapies", "Remarks", c => c.String(maxLength: 200));
            AddColumn("dbo.Physiotherapies", "Remarks", c => c.String(maxLength: 200));
            AddColumn("dbo.OptPatientBills", "Remarks", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OptPatientBills", "Remarks");
            DropColumn("dbo.Physiotherapies", "Remarks");
            DropColumn("dbo.OPDTherapies", "Remarks");
            DropColumn("dbo.InPatientDrugs", "Remarks");
            DropColumn("dbo.InPatientDischarges", "Remarks");
            DropColumn("dbo.InPatientDailyBills", "Remarks");
            DropColumn("dbo.BillingForCheckupPackages", "Remarks");
            DropColumn("dbo.PatientInformations", "Remarks");
        }
    }
}
