namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class investigationondischargesummary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischargeSummaries", "InvestigationDuringAdmission", c => c.String());
            AlterColumn("dbo.InPatientDischargeSummaries", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InPatientDischargeSummaries", "CreatedDate", c => c.String());
            DropColumn("dbo.InPatientDischargeSummaries", "InvestigationDuringAdmission");
        }
    }
}
