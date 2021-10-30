namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diaconflict : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.CanteenFoodInPatientDetails",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            CanteenFoodInPatientId = c.Int(nullable: false),
            //            ProductId = c.String(maxLength: 128),
            //            Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Total = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CanteenFoodInPatients", t => t.CanteenFoodInPatientId, cascadeDelete: true)
            //    .ForeignKey("dbo.Products", t => t.ProductId)
            //    .Index(t => t.CanteenFoodInPatientId)
            //    .Index(t => t.ProductId);
            
            //CreateTable(
            //    "dbo.CanteenFoodInPatients",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(),
            //            PatientCode = c.String(),
            //            GivenAmount = c.Decimal(precision: 18, scale: 2),
            //            ChangeAmount = c.Decimal(precision: 18, scale: 2),
            //            SellsNo = c.String(),
            //            SellsDate = c.DateTime(nullable: false),
            //            VoucherNo = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId)
            //    .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.CanteenFoodInPatientDetails", "ProductId", "dbo.Products");
            //DropForeignKey("dbo.CanteenFoodInPatients", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.CanteenFoodInPatientDetails", "CanteenFoodInPatientId", "dbo.CanteenFoodInPatients");
            //DropIndex("dbo.CanteenFoodInPatients", new[] { "PatientId" });
            //DropIndex("dbo.CanteenFoodInPatientDetails", new[] { "ProductId" });
            //DropIndex("dbo.CanteenFoodInPatientDetails", new[] { "CanteenFoodInPatientId" });
            //DropTable("dbo.CanteenFoodInPatients");
            //DropTable("dbo.CanteenFoodInPatientDetails");
        }
    }
}
