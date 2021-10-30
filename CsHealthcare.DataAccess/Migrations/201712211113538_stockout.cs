namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockOutDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreItemId = c.Int(),
                        StockOutItemId = c.Int(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                        SubTotal = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockOutItems", t => t.StockOutItemId)
                .ForeignKey("dbo.StoreItems", t => t.StoreItemId)
                .Index(t => t.StoreItemId)
                .Index(t => t.StockOutItemId);
            
            CreateTable(
                "dbo.StockOutItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Department = c.String(maxLength: 30),
                        IssuedFor = c.String(maxLength: 30),
                        RecivedBy = c.String(maxLength: 50),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockOutDetails", "StoreItemId", "dbo.StoreItems");
            DropForeignKey("dbo.StockOutDetails", "StockOutItemId", "dbo.StockOutItems");
            DropIndex("dbo.StockOutDetails", new[] { "StockOutItemId" });
            DropIndex("dbo.StockOutDetails", new[] { "StoreItemId" });
            DropTable("dbo.StockOutItems");
            DropTable("dbo.StockOutDetails");
        }
    }
}
