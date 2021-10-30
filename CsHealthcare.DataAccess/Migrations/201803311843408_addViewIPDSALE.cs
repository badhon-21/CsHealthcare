namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addViewIPDSALE : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_IPD_DRUG_SALE",
            //    c => new
            //        {
            //            VID = c.Guid(nullable: false),
            //            Id = c.Int(nullable: false),
            //            VoucherNo = c.String(),
            //            AdmissionNo = c.String(),
            //            PatientId = c.String(),
            //            PatientCode = c.String(),
            //            PatientName = c.String(),
            //            DrugId = c.String(),
            //            DrugName = c.String(),
            //            UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Quantity = c.Int(nullable: false),
            //            SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SaleDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Total = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SaleDateTime = c.String(),
            //            CreatedDate = c.String(),
            //            CreatedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.VID);
            
            //CreateIndex("dbo.StoreItems", "StoreItemCategoryId");
            //AddForeignKey("dbo.StoreItems", "StoreItemCategoryId", "dbo.StoreItemCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.StoreItems", "StoreItemCategoryId", "dbo.StoreItemCategories");
            //DropIndex("dbo.StoreItems", new[] { "StoreItemCategoryId" });
            //DropTable("dbo.VW_IPD_DRUG_SALE");
        }
    }
}
