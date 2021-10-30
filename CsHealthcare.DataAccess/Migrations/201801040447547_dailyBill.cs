namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dailyBill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InPatientDailyBillDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InPatientDailyBillId = c.Int(nullable: false),
                        PurposeId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InPatientDailyBills", t => t.InPatientDailyBillId)
                .ForeignKey("dbo.Purposes", t => t.PurposeId, cascadeDelete: true)
                .Index(t => t.InPatientDailyBillId)
                .Index(t => t.PurposeId);
            
            CreateTable(
                "dbo.InPatientDailyBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(),
                        CabinId = c.Int(),
                        WardId = c.Int(),
                        BedId = c.Int(),
                        DateOfAdmission = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InPatientDailyBillDetails", "PurposeId", "dbo.Purposes");
            DropForeignKey("dbo.InPatientDailyBills", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.InPatientDailyBillDetails", "InPatientDailyBillId", "dbo.InPatientDailyBills");
            DropIndex("dbo.InPatientDailyBills", new[] { "PatientId" });
            DropIndex("dbo.InPatientDailyBillDetails", new[] { "PurposeId" });
            DropIndex("dbo.InPatientDailyBillDetails", new[] { "InPatientDailyBillId" });
            DropTable("dbo.InPatientDailyBills");
            DropTable("dbo.InPatientDailyBillDetails");
        }
    }
}
