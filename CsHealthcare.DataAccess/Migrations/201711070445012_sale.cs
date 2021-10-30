namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sale : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.DrugSaleDetailsHistories",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            DrugId = c.Int(),
            //            DrugSaleHistoryId = c.Int(nullable: false),
            //            UnitPrice = c.Decimal(precision: 18, scale: 2),
            //            Quantity = c.Decimal(precision: 18, scale: 2),
            //            SubTotal = c.Decimal(precision: 18, scale: 2),
            //            SaleDiscount = c.Decimal(precision: 18, scale: 2),
            //            Total = c.Decimal(precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.DRUG", t => t.DrugId)
            //    .ForeignKey("dbo.DrugSaleHistories", t => t.DrugSaleHistoryId)
            //    .Index(t => t.DrugId)
            //    .Index(t => t.DrugSaleHistoryId);
            
            //CreateTable(
            //    "dbo.DrugSaleHistories",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            MemoNo = c.String(maxLength: 50),
            //            TxnNo = c.String(maxLength: 50),
            //            LotId = c.String(maxLength: 50),
            //            PatientId = c.Int(),
            //            SaleQty = c.Decimal(precision: 18, scale: 2),
            //            SalePrice = c.Decimal(precision: 18, scale: 2),
            //            SaleDiscount = c.Decimal(precision: 18, scale: 2),
            //            Vat = c.Decimal(precision: 18, scale: 2),
            //            SpecialDiscount = c.Decimal(precision: 18, scale: 2),
            //            Amount = c.Decimal(precision: 18, scale: 2),
            //            SaleDateTime = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.PatientInformations", t => t.PatientId)
            //    .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.DrugSaleHistories", "PatientId", "dbo.PatientInformations");
            //DropForeignKey("dbo.DrugSaleDetailsHistories", "DrugSaleHistoryId", "dbo.DrugSaleHistories");
            //DropForeignKey("dbo.DrugSaleDetailsHistories", "DrugId", "dbo.DRUG");
            //DropIndex("dbo.DrugSaleHistories", new[] { "PatientId" });
            //DropIndex("dbo.DrugSaleDetailsHistories", new[] { "DrugSaleHistoryId" });
            //DropIndex("dbo.DrugSaleDetailsHistories", new[] { "DrugId" });
            //DropTable("dbo.DrugSaleHistories");
            //DropTable("dbo.DrugSaleDetailsHistories");
        }
    }
}
