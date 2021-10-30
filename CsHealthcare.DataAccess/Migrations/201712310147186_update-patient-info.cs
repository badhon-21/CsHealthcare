namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepatientinfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientInformations", "PatientCode", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientInformations", "PatientCode", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
