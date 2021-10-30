namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drugsale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrugSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(maxLength: 50),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        RecieptNumber = c.String(maxLength: 100),
                        GivenAmount = c.Decimal(precision: 18, scale: 2),
                        ChangeAmount = c.Decimal(precision: 18, scale: 2),
                        RecStatus = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.DrugSaleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugSaleId = c.Int(nullable: false),
                        DRUGId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DRUGId, cascadeDelete: true)
                .ForeignKey("dbo.DrugSales", t => t.DrugSaleId)
                .Index(t => t.DrugSaleId)
                .Index(t => t.DRUGId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrugSales", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.DrugSaleDetails", "DrugSaleId", "dbo.DrugSales");
            DropForeignKey("dbo.DrugSaleDetails", "DRUGId", "dbo.DRUG");
            DropIndex("dbo.DrugSaleDetails", new[] { "DRUGId" });
            DropIndex("dbo.DrugSaleDetails", new[] { "DrugSaleId" });
            DropIndex("dbo.DrugSales", new[] { "PatientId" });
            DropTable("dbo.DrugSaleDetails");
            DropTable("dbo.DrugSales");
        }
    }
}
