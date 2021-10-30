namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upquantity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockOutDetails", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockOutDetails", "Quantity", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
