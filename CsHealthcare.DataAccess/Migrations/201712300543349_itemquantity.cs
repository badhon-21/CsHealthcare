namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemquantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "ItemQuantity", c => c.Int());
            DropColumn("dbo.PatientDetails", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientDetails", "Quantity", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Patients", "ItemQuantity");
        }
    }
}
