namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                        DrugUnitStrength = c.String(maxLength: 80),
                        DrugPresentationType = c.String(),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        SubTotalPrice = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DRUG_MANUFACTURERId = c.Int(nullable: false),
                        MemoNo = c.String(maxLength: 50),
                        TxnNo = c.String(maxLength: 50),
                        LotId = c.String(maxLength: 50),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG_MANUFACTURER", t => t.DRUG_MANUFACTURERId, cascadeDelete: true)
                .Index(t => t.DRUG_MANUFACTURERId);
            
            AddColumn("dbo.DRUG", "Discount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.DRUG", "Tax", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrderDetails", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "DRUG_MANUFACTURERId", "dbo.DRUG_MANUFACTURER");
            DropForeignKey("dbo.PurchaseOrderDetails", "DrugId", "dbo.DRUG");
            DropIndex("dbo.PurchaseOrders", new[] { "DRUG_MANUFACTURERId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "DrugId" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "PurchaseOrderId" });
            DropColumn("dbo.DRUG", "Tax");
            DropColumn("dbo.DRUG", "Discount");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseOrderDetails");
        }
    }
}
