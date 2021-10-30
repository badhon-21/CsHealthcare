namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggg : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.DepartmentDetailsForItems",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            MemoNo = c.String(maxLength: 50),
            //            DepartmentId = c.String(maxLength: 128),
            //            DepartmentName = c.String(),
            //            StockOutItemId = c.Int(nullable: false),
            //            StockOutItemName = c.String(),
            //            TotalQty = c.Decimal(precision: 18, scale: 2),
            //            RemainingQuantity = c.Int(),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
            //    .ForeignKey("dbo.StockOutItems", t => t.StockOutItemId, cascadeDelete: true)
            //    .Index(t => t.DepartmentId)
            //    .Index(t => t.StockOutItemId);
            
            //CreateTable(
            //    "dbo.ItemStockOuts",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            MemoNo = c.String(maxLength: 50),
            //            DepartmentId = c.String(maxLength: 128),
            //            Purpose = c.String(maxLength: 30),
            //            TotalQty = c.Decimal(precision: 18, scale: 2),
            //            PurposeBy = c.String(),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
            //    .Index(t => t.DepartmentId);
            
            //CreateTable(
            //    "dbo.ItemStockOutDetails",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ItemStockOutId = c.Int(),
            //            StoreItemId = c.Int(),
            //            StoreItemName = c.String(),
            //            Quantity = c.Decimal(precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.ItemStockOuts", t => t.ItemStockOutId)
            //    .Index(t => t.ItemStockOutId);
            
            //AddColumn("dbo.StockOutItems", "DepartmentId", c => c.String(maxLength: 128));
            //CreateIndex("dbo.StockOutItems", "DepartmentId");
            //AddForeignKey("dbo.StockOutItems", "DepartmentId", "dbo.DEPARTMENTs", "Id");
            //DropColumn("dbo.StockOutItems", "Department");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.StockOutItems", "Department", c => c.String(maxLength: 30));
            //DropForeignKey("dbo.ItemStockOutDetails", "ItemStockOutId", "dbo.ItemStockOuts");
            //DropForeignKey("dbo.ItemStockOuts", "DepartmentId", "dbo.DEPARTMENTs");
            //DropForeignKey("dbo.DepartmentDetailsForItems", "StockOutItemId", "dbo.StockOutItems");
            //DropForeignKey("dbo.StockOutItems", "DepartmentId", "dbo.DEPARTMENTs");
            //DropForeignKey("dbo.DepartmentDetailsForItems", "DepartmentId", "dbo.DEPARTMENTs");
            //DropIndex("dbo.ItemStockOutDetails", new[] { "ItemStockOutId" });
            //DropIndex("dbo.ItemStockOuts", new[] { "DepartmentId" });
            //DropIndex("dbo.StockOutItems", new[] { "DepartmentId" });
            //DropIndex("dbo.DepartmentDetailsForItems", new[] { "StockOutItemId" });
            //DropIndex("dbo.DepartmentDetailsForItems", new[] { "DepartmentId" });
            //DropColumn("dbo.StockOutItems", "DepartmentId");
            //DropTable("dbo.ItemStockOutDetails");
            //DropTable("dbo.ItemStockOuts");
            //DropTable("dbo.DepartmentDetailsForItems");
        }
    }
}
