namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DrugSales", "DrugId", "dbo.DRUG");
            DropIndex("dbo.DrugSales", new[] { "DrugId" });
            CreateTable(
                "dbo.DrugSaleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugId = c.Int(),
                        DrugSaleId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                        SubTotal = c.Decimal(precision: 18, scale: 2),
                        SaleDiscount = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId)
                .ForeignKey("dbo.DrugSales", t => t.DrugSaleId)
                .Index(t => t.DrugId)
                .Index(t => t.DrugSaleId);
            
            DropColumn("dbo.DrugSales", "DrugId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugSales", "DrugId", c => c.Int());
            DropForeignKey("dbo.DrugSaleDetails", "DrugSaleId", "dbo.DrugSales");
            DropForeignKey("dbo.DrugSaleDetails", "DrugId", "dbo.DRUG");
            DropIndex("dbo.DrugSaleDetails", new[] { "DrugSaleId" });
            DropIndex("dbo.DrugSaleDetails", new[] { "DrugId" });
            DropTable("dbo.DrugSaleDetails");
            CreateIndex("dbo.DrugSales", "DrugId");
            AddForeignKey("dbo.DrugSales", "DrugId", "dbo.DRUG", "D_ID");
        }
    }
}
