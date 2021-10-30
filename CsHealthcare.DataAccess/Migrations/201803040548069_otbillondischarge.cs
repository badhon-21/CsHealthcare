namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otbillondischarge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "OTBill", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.InPatientDischarges", "ICUBill", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "ICUBill");
            DropColumn("dbo.InPatientDischarges", "OTBill");
        }
    }
}
