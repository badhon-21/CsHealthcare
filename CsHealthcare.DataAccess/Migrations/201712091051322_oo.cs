namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oo : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Patients", "Discount", c => c.Decimal(precision: 18, scale: 2));
            //AddColumn("dbo.Patients", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Patients", "TotalAmount");
            //DropColumn("dbo.Patients", "Discount");
        }
    }
}
