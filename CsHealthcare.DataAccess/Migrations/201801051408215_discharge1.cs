namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discharge1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InPatientDischarges", "TotalBill", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InPatientDischarges", "TotalBill");
        }
    }
}
