namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itstockout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemStockOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemoNo = c.String(maxLength: 50),
                        DepartmentId = c.String(maxLength: 128),
                        Purpose = c.String(maxLength: 30),
                        TotalQty = c.Decimal(precision: 18, scale: 2),
                        PurposeBy = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.ItemStockOutDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemStockOutId = c.Int(),
                        StockOutItemName = c.String(),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemStockOuts", t => t.ItemStockOutId)
                .Index(t => t.ItemStockOutId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemStockOutDetails", "ItemStockOutId", "dbo.ItemStockOuts");
            DropForeignKey("dbo.ItemStockOuts", "DepartmentId", "dbo.DEPARTMENTs");
            DropIndex("dbo.ItemStockOutDetails", new[] { "ItemStockOutId" });
            DropIndex("dbo.ItemStockOuts", new[] { "DepartmentId" });
            DropTable("dbo.ItemStockOutDetails");
            DropTable("dbo.ItemStockOuts");
        }
    }
}
