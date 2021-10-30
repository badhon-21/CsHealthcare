namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class operationtimechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InPatientDischargeSummaries", "OperationTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InPatientDischargeSummaries", "OperationTime", c => c.DateTime(nullable: false));
        }
    }
}
