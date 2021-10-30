namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockdetails1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockOutItems", "TotalQty", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.StockOutItems", "Amount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockOutItems", "Amount");
            DropColumn("dbo.StockOutItems", "TotalQty");
        }
    }
}
