namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientInformations", "PatientCode", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Patients", "PatientCode", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "PatientCode");
            DropColumn("dbo.PatientInformations", "PatientCode");
        }
    }
}
