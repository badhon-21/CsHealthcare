namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TxnNo = c.String(maxLength: 50),
                        LotId = c.String(nullable: false, maxLength: 50),
                        StoreItemId = c.Int(nullable: false),
                        InvNo = c.String(nullable: false, maxLength: 50),
                        DpoId = c.String(maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvDate = c.DateTime(nullable: false),
                        RecordDate = c.DateTime(),
                        PaymentStatus = c.String(nullable: false, maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StoreItems", t => t.StoreItemId, cascadeDelete: true)
                .Index(t => t.StoreItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockIns", "StoreItemId", "dbo.StoreItems");
            DropIndex("dbo.StockIns", new[] { "StoreItemId" });
            DropTable("dbo.StockIns");
        }
    }
}
