namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billingforPackageCheckup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingForCheckupPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientCode = c.String(),
                        PatientName = c.String(),
                        ReferanceName = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        BloodGroup = c.String(maxLength: 20),
                        Address = c.String(maxLength: 200),
                        Sex = c.String(maxLength: 20),
                        OccupationId = c.Int(),
                        EducationId = c.Int(),
                        MobileNumber = c.String(maxLength: 20),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GivenAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherNo = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillingForCheckupPackageDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageForCheckUpId = c.Int(nullable: false),
                        BillingForCheckupPackageId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingForCheckupPackages", t => t.BillingForCheckupPackageId, cascadeDelete: true)
                .ForeignKey("dbo.PackageForCheckUps", t => t.PackageForCheckUpId, cascadeDelete: true)
                .Index(t => t.PackageForCheckUpId)
                .Index(t => t.BillingForCheckupPackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillingForCheckupPackageDetails", "PackageForCheckUpId", "dbo.PackageForCheckUps");
            DropForeignKey("dbo.BillingForCheckupPackageDetails", "BillingForCheckupPackageId", "dbo.BillingForCheckupPackages");
            DropIndex("dbo.BillingForCheckupPackageDetails", new[] { "BillingForCheckupPackageId" });
            DropIndex("dbo.BillingForCheckupPackageDetails", new[] { "PackageForCheckUpId" });
            DropTable("dbo.BillingForCheckupPackageDetails");
            DropTable("dbo.BillingForCheckupPackages");
        }
    }
}
