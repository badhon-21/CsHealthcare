namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addViewIPDSALEReurn : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VW_IPD_DRUG_SALE_RETURN",
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
            //            ReturnPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            ReturnDate = c.DateTime(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //            CreatedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.VID);
            
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "SaleDateTime", c => c.DateTime(nullable: false));
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "CreatedDate", c => c.String());
            //AlterColumn("dbo.VW_IPD_DRUG_SALE", "SaleDateTime", c => c.String());
            //DropTable("dbo.VW_IPD_DRUG_SALE_RETURN");
        }
    }
}
