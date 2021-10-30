namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientcodeonreturn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDrugSaleReturns", "PatientCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDrugSaleReturns", "PatientCode");
        }
    }
}
