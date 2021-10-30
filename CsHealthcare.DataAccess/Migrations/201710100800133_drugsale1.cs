namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drugsale1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DrugSaleDetails", "DRUGId", "dbo.DRUG");
            DropForeignKey("dbo.DrugSaleDetails", "DrugSaleId", "dbo.DrugSales");
            DropForeignKey("dbo.DrugSales", "PatientId", "dbo.Patients");
            DropIndex("dbo.DrugSales", new[] { "PatientId" });
            DropIndex("dbo.DrugSaleDetails", new[] { "DrugSaleId" });
            DropIndex("dbo.DrugSaleDetails", new[] { "DRUGId" });
            DropTable("dbo.DrugSales");
            DropTable("dbo.DrugSaleDetails");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.DrugSaleDetails", "DRUGId");
            CreateIndex("dbo.DrugSaleDetails", "DrugSaleId");
            CreateIndex("dbo.DrugSales", "PatientId");
            AddForeignKey("dbo.DrugSales", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DrugSaleDetails", "DrugSaleId", "dbo.DrugSales", "Id");
            AddForeignKey("dbo.DrugSaleDetails", "DRUGId", "dbo.DRUG", "D_ID", cascadeDelete: true);
        }
    }
}
