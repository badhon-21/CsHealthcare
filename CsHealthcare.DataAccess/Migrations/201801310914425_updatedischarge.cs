namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedischarge : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InPatientDischarges", "PackageId", c => c.Int());
            AlterColumn("dbo.InPatientDischarges", "PackageAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InPatientDischarges", "PackageAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InPatientDischarges", "PackageId", c => c.Int(nullable: false));
        }
    }
}
