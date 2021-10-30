namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discountforphysiotherapy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpdTherapyDetails", "Quantity", c => c.Int());
            AddColumn("dbo.OpdTherapyDetails", "Discount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpdTherapyDetails", "Discount");
            DropColumn("dbo.OpdTherapyDetails", "Quantity");
        }
    }
}
