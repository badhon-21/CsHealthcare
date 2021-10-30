namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inpatientdrugsalereturn1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientDrugSaleReturnDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPatientDrugSaleReturnId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DRUG", t => t.DrugId, cascadeDelete: true)
                .ForeignKey("dbo.InPatientDrugSaleReturns", t => t.InPatientDrugSaleReturnId)
                .Index(t => t.InPatientDrugSaleReturnId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.InPatientDrugSaleReturns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemoNo = c.String(nullable: false, maxLength: 50),
                        LotNo = c.String(nullable: false, maxLength: 50),
                        ReturnPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnSubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        TxnNo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InPatientDrugSaleReturnDetails", "InPatientDrugSaleReturnId", "dbo.InPatientDrugSaleReturns");
            DropForeignKey("dbo.InPatientDrugSaleReturnDetails", "DrugId", "dbo.DRUG");
            DropIndex("dbo.InPatientDrugSaleReturnDetails", new[] { "DrugId" });
            DropIndex("dbo.InPatientDrugSaleReturnDetails", new[] { "InPatientDrugSaleReturnId" });
            DropTable("dbo.InPatientDrugSaleReturns");
            DropTable("dbo.InPatientDrugSaleReturnDetails");
        }
    }
}
