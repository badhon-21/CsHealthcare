namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "NetCollectionAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.PatientDueCollections", "TestId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientDueCollections", "TestId");
            DropColumn("dbo.Patients", "NetCollectionAmount");
        }
    }
}
