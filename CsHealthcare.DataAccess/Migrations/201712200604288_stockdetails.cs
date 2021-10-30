namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockdetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockInDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockInId = c.Int(),
                        StoreItemId = c.Int(),
                        CostPrice = c.Decimal(precision: 18, scale: 2),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        SubTotalPrice = c.Decimal(precision: 18, scale: 2),
                        SalePrice = c.Decimal(precision: 18, scale: 2),
                        StockQuantity = c.Int(),
                        AvailableQuantity = c.Int(),
                        DisturbedQuantity = c.Int(),
                        RemainingQuantity = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockIns", t => t.StockInId)
                .ForeignKey("dbo.StoreItems", t => t.StoreItemId)
                .Index(t => t.StockInId)
                .Index(t => t.StoreItemId);
            
            DropColumn("dbo.StockIns", "PaymentStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockIns", "PaymentStatus", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.StockInDetails", "StoreItemId", "dbo.StoreItems");
            DropForeignKey("dbo.StockInDetails", "StockInId", "dbo.StockIns");
            DropIndex("dbo.StockInDetails", new[] { "StoreItemId" });
            DropIndex("dbo.StockInDetails", new[] { "StockInId" });
            DropTable("dbo.StockInDetails");
        }
    }
}
