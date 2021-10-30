namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qqq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InPatientDailyBillDetails", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InPatientDailyBillDetails", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
