namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationforconflict : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_Department1_Wise_DRUG_STOCK",
            //    c => new
            //        {
            //            ID = c.Guid(nullable: false),
            //            D_ID = c.Int(nullable: false),
            //            D_TRADE_NAME = c.String(),
            //            D_UNIT_STRENGTH = c.String(),
            //            DPT_DESCRIPTION = c.String(),
            //            drugName = c.String(),
            //            StockQuantity = c.Int(nullable: false),
            //            SaleQuantity = c.Int(nullable: false),
            //            BufferStock = c.Int(nullable: false),
            //            HospitalSale = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.VW_Department1_Wise_DRUG_STOCK");
        }
    }
}
