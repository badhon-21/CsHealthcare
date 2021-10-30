namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(),
            //            PictureUrl = c.String(),
            //            Description = c.String(),
            //            IsFeaturedProduct = c.Boolean(nullable: false),
            //            DisplayOrder = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            CategoryId = c.String(maxLength: 128),
            //            Name = c.String(),
            //            ShortDescription = c.String(),
            //            FullDescription = c.String(),
            //            SupplierId = c.String(),
            //            StockQuantity = c.Int(nullable: false),
            //            MinStockQuantity = c.Int(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            ProductCost = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SpecialPrice = c.Decimal(precision: 18, scale: 2),
            //            SpecialPriceStartDateTimeUtc = c.DateTime(),
            //            SpecialPriceEndDateTimeUtc = c.DateTime(),
            //            PictureUrl = c.String(),
            //            Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Length = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Width = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Height = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Published = c.Boolean(nullable: false),
            //            Deleted = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Categories", t => t.CategoryId)
            //    .Index(t => t.CategoryId);
            
            //CreateTable(
            //    "dbo.SellsDetails",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            SellsId = c.String(nullable: false, maxLength: 128),
            //            ProductId = c.String(nullable: false, maxLength: 128),
            //            Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            TotalCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Discount = c.Decimal(precision: 18, scale: 2),
            //            Total = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
            //    .ForeignKey("dbo.Sells", t => t.SellsId, cascadeDelete: true)
            //    .Index(t => t.SellsId)
            //    .Index(t => t.ProductId);
            
            //CreateTable(
            //    "dbo.Sells",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            CustomerId = c.String(maxLength: 128),
            //            SellsNo = c.String(nullable: false, maxLength: 100),
            //            SellsDate = c.DateTime(nullable: false),
            //            SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            GrandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Status = c.String(maxLength: 50),
            //            Note = c.String(),
            //            Discount = c.Decimal(precision: 18, scale: 2),
            //            TransactionType = c.String(maxLength: 100),
            //            TransactionNumber = c.String(maxLength: 100),
            //            GivenAmount = c.Decimal(precision: 18, scale: 2),
            //            ChangeAmount = c.Decimal(precision: 18, scale: 2),
            //            RecStatus = c.String(maxLength: 50),
            //            CreatedDate = c.DateTime(),
            //            ModifiedDate = c.DateTime(),
            //            CreatedBy = c.String(maxLength: 50),
            //            ModifiedBy = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Customers", t => t.CustomerId)
            //    .Index(t => t.CustomerId);
            
            //CreateTable(
            //    "dbo.Customers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 100),
            //            FirstName = c.String(maxLength: 50),
            //            LastName = c.String(maxLength: 50),
            //            CardId = c.String(nullable: false, maxLength: 50),
            //            Email = c.String(nullable: false, maxLength: 50),
            //            Telephone = c.String(maxLength: 50),
            //            Mobile = c.String(maxLength: 50),
            //            AddressOne = c.String(maxLength: 100),
            //            AddressTwo = c.String(maxLength: 100),
            //            CityName = c.String(maxLength: 50),
            //            Country = c.String(maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.SellsDetails", "SellsId", "dbo.Sells");
            //DropForeignKey("dbo.Sells", "CustomerId", "dbo.Customers");
            //DropForeignKey("dbo.SellsDetails", "ProductId", "dbo.Products");
            //DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            //DropIndex("dbo.Sells", new[] { "CustomerId" });
            //DropIndex("dbo.SellsDetails", new[] { "ProductId" });
            //DropIndex("dbo.SellsDetails", new[] { "SellsId" });
            //DropIndex("dbo.Products", new[] { "CategoryId" });
            //DropTable("dbo.Customers");
            //DropTable("dbo.Sells");
            //DropTable("dbo.SellsDetails");
            //DropTable("dbo.Products");
            //DropTable("dbo.Categories");
        }
    }
}
