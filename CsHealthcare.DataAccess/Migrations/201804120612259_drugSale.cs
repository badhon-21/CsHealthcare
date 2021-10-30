namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drugSale : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_DRUG_SALE_ALL",
            //    c => new
            //        {
            //            VID = c.Guid(nullable: false),
            //            Ctype = c.String(),
            //            MemoNo = c.String(),
            //            DrugId = c.Int(nullable: false),
            //            DrugName = c.String(),
            //            UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CreatedDate = c.DateTime(nullable: false),
            //            CreatedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.VID);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.VW_DRUG_SALE_ALL");
        }
    }
}
