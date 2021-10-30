namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optpatient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OptPatientBillDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurposeId = c.Int(nullable: false),
                        OptPatientBillId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OptPatientBills", t => t.OptPatientBillId)
                .ForeignKey("dbo.Purposes", t => t.PurposeId, cascadeDelete: true)
                .Index(t => t.PurposeId)
                .Index(t => t.OptPatientBillId);
            
            CreateTable(
                "dbo.OptPatientBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(),
                        PatientName = c.String(),
                        FatherName = c.String(maxLength: 100),
                        MotherName = c.String(maxLength: 100),
                        ReferanceName = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        BloodGroup = c.String(maxLength: 20),
                        Address = c.String(maxLength: 200),
                        Sex = c.String(maxLength: 20),
                        OccupationId = c.Int(),
                        EducationId = c.Int(),
                        MobileNumber = c.String(maxLength: 20),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherNo = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OptPatientBillDetails", "PurposeId", "dbo.Purposes");
            DropForeignKey("dbo.OptPatientBillDetails", "OptPatientBillId", "dbo.OptPatientBills");
            DropIndex("dbo.OptPatientBillDetails", new[] { "OptPatientBillId" });
            DropIndex("dbo.OptPatientBillDetails", new[] { "PurposeId" });
            DropTable("dbo.OptPatientBills");
            DropTable("dbo.OptPatientBillDetails");
        }
    }
}
