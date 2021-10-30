namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LCNo = c.Int(nullable: false),
                        IssueDate = c.DateTime(),
                        BeneficiayName = c.String(maxLength: 100),
                        Origin = c.String(maxLength: 50),
                        Item = c.String(maxLength: 100),
                        Quantity = c.String(maxLength: 20),
                        Tenor = c.String(maxLength: 50),
                        LCValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Port = c.String(maxLength: 20),
                        ShipDate = c.DateTime(),
                        InvoiceNo = c.String(maxLength: 50),
                        InvoiceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BLNo = c.String(maxLength: 100),
                        ShipQty = c.String(maxLength: 20),
                        ETA = c.DateTime(),
                        PaidOn = c.DateTime(),
                        UPassDue = c.DateTime(),
                        Rmks = c.String(maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LCs");
        }
    }
}
