namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class packageondischarge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "PackageId", c => c.Int(nullable: false));
            AddColumn("dbo.InPatientDischarges", "PackageAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "PackageAmount");
            DropColumn("dbo.InPatientDischarges", "PackageId");
        }
    }
}
