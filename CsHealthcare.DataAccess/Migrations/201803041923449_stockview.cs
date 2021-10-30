namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockview : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_DRUG_STOCK",
            //    c => new
            //        {
            //            ID = c.Guid(nullable: false),
            //            D_ID = c.String(),
            //            D_TRADE_NAME = c.String(),
            //            D_UNIT_STRENGTH = c.String(),
            //            DPT_DESCRIPTION = c.String(),
            //            drugName = c.String(),
            //            ComId = c.String(),
            //            ComName = c.String(),
            //            LotId = c.String(),
            //            InvNo = c.String(),
            //            InvDate = c.DateTime(nullable: false),
            //            RecordDate = c.DateTime(nullable: false),
            //            DpoId = c.String(),
            //            D_REORDER_LEVEL = c.Int(nullable: false),
            //            MafDate = c.DateTime(nullable: false),
            //            ExpDate = c.DateTime(nullable: false),
            //            CostPrice = c.Decimal(precision: 18, scale: 2),
            //            DSD_COST_TOTAL_PRICE = c.Decimal(precision: 18, scale: 2),
            //            UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            StockQuantity = c.Int(nullable: false),
            //            AvailableQuantity = c.Int(),
            //            DisturbedQuantity = c.Int(),
            //            RemainingQuantity = c.Int(),
            //            DiscountPercent = c.Decimal(precision: 18, scale: 2),
            //            stockDetailsId = c.Int(nullable: false),
            //            DrugStockInId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
           // DropTable("dbo.VW_DRUG_STOCK");
        }
    }
}
