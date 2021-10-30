namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedraft1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_DRUG_CONDITION",
            //    c => new
            //        {
            //            VID = c.Guid(nullable: false),
            //            CompanyName = c.String(),
            //            drugName = c.String(),
            //            box_size = c.Int(nullable: false),
            //            ReorderLevel = c.Int(nullable: false),
            //            MRP = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            totalSaleQty = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            totalSaleAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            totalStockQty = c.Int(nullable: false),
            //            totalreminingQty = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.VID);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.VW_DRUG_CONDITION");
        }
    }
}
