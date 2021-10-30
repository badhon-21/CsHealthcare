namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Amenities",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 200),
            //            Url = c.String(maxLength: 500),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.CabinAmenities",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            AmenityId = c.Int(nullable: false),
            //            CabinId = c.Int(nullable: false),
            //            Status = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Amenities", t => t.AmenityId, cascadeDelete: true)
            //    .ForeignKey("dbo.Cabins", t => t.CabinId, cascadeDelete: true)
            //    .Index(t => t.AmenityId)
            //    .Index(t => t.CabinId);
            
            //CreateTable(
            //    "dbo.Cabins",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            CabinTypeId = c.Int(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 200),
            //            Description = c.String(maxLength: 200),
            //            PriceByDay = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            RecStatus = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //            ModifiedDate = c.DateTime(),
            //            CreatedBy = c.String(),
            //            ModifiedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CabinTypes", t => t.CabinTypeId, cascadeDelete: true)
            //    .Index(t => t.CabinTypeId);
            
            //CreateTable(
            //    "dbo.CabinRents",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            CabinId = c.Int(nullable: false),
            //            PatientId = c.Int(nullable: false),
            //            MobileNo = c.String(nullable: false, maxLength: 50),
            //            EmergencyContactPerson = c.String(nullable: false),
            //            RentDate = c.DateTime(nullable: false),
            //            Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Duration = c.String(maxLength: 50),
            //            TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            RecStatus = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //            ModifiedDate = c.DateTime(),
            //            CreatedBy = c.String(),
            //            ModifiedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Cabins", t => t.CabinId, cascadeDelete: true)
            //    .ForeignKey("dbo.PatientInformations", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.CabinId)
            //    .Index(t => t.PatientId);
            
            //CreateTable(
            //    "dbo.CabinTypes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 200),
            //            Status = c.String(maxLength: 10),
            //            RecStatus = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //            ModifiedDate = c.DateTime(),
            //            CreatedBy = c.String(),
            //            ModifiedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.GlTransactions",
            //    c => new
            //        {
            //            GT_ID = c.Int(nullable: false, identity: true),
            //            GT_GL_ID = c.String(maxLength: 20),
            //            GT_TR_CODE = c.String(maxLength: 10),
            //            GT_TXN_NO = c.String(maxLength: 50),
            //            GT_AMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            GT_TRANS_DATE = c.DateTime(),
            //            GT_NARATION = c.String(maxLength: 250),
            //            RecStatus = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //            ModifiedDate = c.DateTime(),
            //            CreatedBy = c.String(),
            //            ModifiedBy = c.String(),
            //        })
            //    .PrimaryKey(t => t.GT_ID);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Cabins", "CabinTypeId", "dbo.CabinTypes");
            //DropForeignKey("dbo.CabinRents", "PatientId", "dbo.PatientInformations");
            //DropForeignKey("dbo.CabinRents", "CabinId", "dbo.Cabins");
            //DropForeignKey("dbo.CabinAmenities", "CabinId", "dbo.Cabins");
            //DropForeignKey("dbo.CabinAmenities", "AmenityId", "dbo.Amenities");
            //DropIndex("dbo.CabinRents", new[] { "PatientId" });
            //DropIndex("dbo.CabinRents", new[] { "CabinId" });
            //DropIndex("dbo.Cabins", new[] { "CabinTypeId" });
            //DropIndex("dbo.CabinAmenities", new[] { "CabinId" });
            //DropIndex("dbo.CabinAmenities", new[] { "AmenityId" });
            //DropTable("dbo.GlTransactions");
            //DropTable("dbo.CabinTypes");
            //DropTable("dbo.CabinRents");
            //DropTable("dbo.Cabins");
            //DropTable("dbo.CabinAmenities");
            //DropTable("dbo.Amenities");
        }
    }
}
