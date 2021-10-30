namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testquantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientDetails", "Quantity", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientDetails", "Quantity");
        }
    }
}
