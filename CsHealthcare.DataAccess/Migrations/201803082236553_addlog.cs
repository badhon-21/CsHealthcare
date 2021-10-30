namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IpdDrafts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(),
                        CabinId = c.Int(),
                        WardId = c.Int(),
                        BedId = c.Int(),
                        CabinAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPatientDailyBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPatientDrugBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPatientDoctorBills = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InPatientTotalTestBills = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        VoucherNo = c.String(),
                        DischargeDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        PackageId = c.Int(),
                        PackageAmount = c.Decimal(precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        DiscountReason = c.String(),
                        DoctorDiscount = c.Decimal(precision: 18, scale: 2),
                        NameOfDoctorOnDiscount = c.String(),
                        AdmissionFee = c.Decimal(precision: 18, scale: 2),
                        OTBill = c.Decimal(precision: 18, scale: 2),
                        ICUBill = c.Decimal(precision: 18, scale: 2),
                        RecStatus = c.String(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            AddColumn("dbo.InPatientDischarges", "RecStatus", c => c.String());
            AddColumn("dbo.InPatientDischarges", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.InPatientDischarges", "CreatedBy", c => c.String());
            AddColumn("dbo.InPatientDischarges", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IpdDrafts", "PatientId", "dbo.Patients");
            DropIndex("dbo.IpdDrafts", new[] { "PatientId" });
            DropColumn("dbo.InPatientDischarges", "ModifiedBy");
            DropColumn("dbo.InPatientDischarges", "CreatedBy");
            DropColumn("dbo.InPatientDischarges", "ModifiedDate");
            DropColumn("dbo.InPatientDischarges", "RecStatus");
            DropTable("dbo.IpdDrafts");
        }
    }
}
