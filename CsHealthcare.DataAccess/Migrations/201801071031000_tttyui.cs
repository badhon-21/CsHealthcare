namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tttyui : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.InPatientDailyBillDetails",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            InPatientDailyBillId = c.Int(nullable: false),
            //            PurposeId = c.Int(nullable: false),
            //            Quantity = c.Int(),
            //            Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Total = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.InPatientDailyBills", t => t.InPatientDailyBillId)
            //    .ForeignKey("dbo.Purposes", t => t.PurposeId, cascadeDelete: true)
            //    .Index(t => t.InPatientDailyBillId)
            //    .Index(t => t.PurposeId);
            
            //CreateTable(
            //    "dbo.InPatientDailyBills",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(nullable: false),
            //            PatientCode = c.String(),
            //            CabinId = c.Int(),
            //            WardId = c.Int(),
            //            BedId = c.Int(),
            //            DateOfAdmission = c.DateTime(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //            SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Total = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            VoucherNo = c.String(),
            //            NoOfDays = c.Int(nullable: false),
            //            TransactionType = c.String(),
            //            TransactionNumber = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId);
            
            //CreateTable(
            //    "dbo.InPatientDischarges",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(nullable: false),
            //            PatientCode = c.String(),
            //            CabinId = c.Int(),
            //            WardId = c.Int(),
            //            BedId = c.Int(),
            //            CabinAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            InPatientDailyBill = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            InPatientDrugBill = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            InPatientDoctorBills = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            InPatientTotalTestBills = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            TotalBill = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Status = c.String(),
            //            VoucherNo = c.String(),
            //            DischargeDate = c.DateTime(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId);
            
            //CreateTable(
            //    "dbo.InPatientDoctorInvoices",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(nullable: false),
            //            PatientCode = c.String(),
            //            DoctorId = c.String(maxLength: 128),
            //            Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Date = c.DateTime(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.DoctorInformations", t => t.DoctorId)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId)
            //    .Index(t => t.DoctorId);
            
            //CreateTable(
            //    "dbo.InPatientDrugDetails",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            DrugId = c.Int(),
            //            InPatientDrugId = c.Int(nullable: false),
            //            UnitPrice = c.Decimal(precision: 18, scale: 2),
            //            Quantity = c.Decimal(precision: 18, scale: 2),
            //            SubTotal = c.Decimal(precision: 18, scale: 2),
            //            SaleDiscount = c.Decimal(precision: 18, scale: 2),
            //            Total = c.Decimal(precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.DRUG", t => t.DrugId)
            //    .ForeignKey("dbo.InPatientDrugs", t => t.InPatientDrugId)
            //    .Index(t => t.DrugId)
            //    .Index(t => t.InPatientDrugId);
            
            //CreateTable(
            //    "dbo.InPatientDrugs",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(),
            //            PatientCode = c.String(),
            //            Quantity = c.Decimal(precision: 18, scale: 2),
            //            SaleDiscount = c.Decimal(precision: 18, scale: 2),
            //            Vat = c.Decimal(precision: 18, scale: 2),
            //            SpecialDiscount = c.Decimal(precision: 18, scale: 2),
            //            TotalPrice = c.Decimal(precision: 18, scale: 2),
            //            SaleDateTime = c.DateTime(),
            //            VoucherNo = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId)
            //    .Index(t => t.PatientId);
            
            //CreateTable(
            //    "dbo.InPatientTestdetails",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            InPatientTestId = c.Int(nullable: false),
            //            TestNameId = c.Int(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Discount = c.Decimal(precision: 18, scale: 2),
            //            Total = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.InPatientTests", t => t.InPatientTestId)
            //    .ForeignKey("dbo.Test_Name", t => t.TestNameId, cascadeDelete: true)
            //    .Index(t => t.InPatientTestId)
            //    .Index(t => t.TestNameId);
            
            //CreateTable(
            //    "dbo.InPatientTests",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientCode = c.String(nullable: false, maxLength: 100),
            //            PatientId = c.Int(nullable: false),
            //            DeuAmount = c.Decimal(precision: 18, scale: 2),
            //            VoucherNo = c.String(maxLength: 100),
            //            ItemQuantity = c.Int(),
            //            TestDate = c.DateTime(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId);
            
            //CreateTable(
            //    "dbo.PatientLasers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(nullable: false),
            //            PatientCode = c.String(),
            //            CabinId = c.Int(),
            //            WardId = c.Int(),
            //            BedId = c.Int(),
            //            AdvanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            AdvanceType = c.String(),
            //            ChequeNumber = c.String(),
            //            BankName = c.String(),
            //            Remarks = c.String(),
            //            ReceivedDate = c.DateTime(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId);
            
            //AddColumn("dbo.PatientAdmissions", "Status", c => c.String());
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.PatientLasers", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.InPatientTestdetails", "TestNameId", "dbo.Test_Name");
            //DropForeignKey("dbo.InPatientTests", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.InPatientTestdetails", "InPatientTestId", "dbo.InPatientTests");
            //DropForeignKey("dbo.InPatientDrugs", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.InPatientDrugDetails", "InPatientDrugId", "dbo.InPatientDrugs");
            //DropForeignKey("dbo.InPatientDrugDetails", "DrugId", "dbo.DRUG");
            //DropForeignKey("dbo.InPatientDoctorInvoices", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.InPatientDoctorInvoices", "DoctorId", "dbo.DoctorInformations");
            //DropForeignKey("dbo.InPatientDischarges", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.InPatientDailyBillDetails", "PurposeId", "dbo.Purposes");
            //DropForeignKey("dbo.InPatientDailyBills", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.InPatientDailyBillDetails", "InPatientDailyBillId", "dbo.InPatientDailyBills");
            //DropIndex("dbo.PatientLasers", new[] { "PatientId" });
            //DropIndex("dbo.InPatientTests", new[] { "PatientId" });
            //DropIndex("dbo.InPatientTestdetails", new[] { "TestNameId" });
            //DropIndex("dbo.InPatientTestdetails", new[] { "InPatientTestId" });
            //DropIndex("dbo.InPatientDrugs", new[] { "PatientId" });
            //DropIndex("dbo.InPatientDrugDetails", new[] { "InPatientDrugId" });
            //DropIndex("dbo.InPatientDrugDetails", new[] { "DrugId" });
            //DropIndex("dbo.InPatientDoctorInvoices", new[] { "DoctorId" });
            //DropIndex("dbo.InPatientDoctorInvoices", new[] { "PatientId" });
            //DropIndex("dbo.InPatientDischarges", new[] { "PatientId" });
            //DropIndex("dbo.InPatientDailyBills", new[] { "PatientId" });
            //DropIndex("dbo.InPatientDailyBillDetails", new[] { "PurposeId" });
            //DropIndex("dbo.InPatientDailyBillDetails", new[] { "InPatientDailyBillId" });
            //DropColumn("dbo.PatientAdmissions", "Status");
            //DropTable("dbo.PatientLasers");
            //DropTable("dbo.InPatientTests");
            //DropTable("dbo.InPatientTestdetails");
            //DropTable("dbo.InPatientDrugs");
            //DropTable("dbo.InPatientDrugDetails");
            //DropTable("dbo.InPatientDoctorInvoices");
            //DropTable("dbo.InPatientDischarges");
            //DropTable("dbo.InPatientDailyBills");
            //DropTable("dbo.InPatientDailyBillDetails");
        }
    }
}
