namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugStockIns", "NetAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DrugStockIns", "VatAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DrugStockIns", "DiscountAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DrugStockIns", "DiscountAmount");
            DropColumn("dbo.DrugStockIns", "VatAmount");
            DropColumn("dbo.DrugStockIns", "NetAmount");
        }
    }
}
