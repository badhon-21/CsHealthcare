namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstatusontestname : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_DRUG_AVILABLE_STOCK",
            //    c => new
            //        {
            //            ID = c.Guid(nullable: false),
            //            DrugID = c.Int(nullable: false),
            //            drugName = c.String(),
            //            D_TRADE_NAME = c.String(),
            //            D_UNIT_STRENGTH = c.String(),
            //            DPT_DESCRIPTION = c.String(),
            //            COST_PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            QTY = c.Int(nullable: false),
            //            PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            DISCOUNT = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Test_Name", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Test_Name", "Status");
            //DropTable("dbo.VW_DRUG_AVILABLE_STOCK");
        }
    }
}
