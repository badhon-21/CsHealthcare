namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateconflict : DbMigration
    {
        public override void Up()
        {
        //    CreateTable(
        //        "dbo.OPDTherapies",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                PatientCode = c.String(),
        //                PatientName = c.String(),
        //                FatherName = c.String(),
        //                MotherName = c.String(),
        //                ReferanceName = c.String(),
        //                Age = c.Int(nullable: false),
        //                BloodGroup = c.String(),
        //                Address = c.String(),
        //                Sex = c.String(),
        //                OccupationId = c.Int(),
        //                EducationId = c.Int(),
        //                MobileNumber = c.String(),
        //                TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                GivenAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                VoucherNo = c.String(),
        //                CreatedDate = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.OpdTherapyDetails",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                OPDTherapyId = c.Int(nullable: false),
        //                TherapyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                PhysiotherapyId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Physiotherapies", t => t.PhysiotherapyId, cascadeDelete: true)
        //        .ForeignKey("dbo.OPDTherapies", t => t.OPDTherapyId)
        //        .Index(t => t.OPDTherapyId)
        //        .Index(t => t.PhysiotherapyId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.OpdTherapyDetails", "OPDTherapyId", "dbo.OPDTherapies");
            //DropForeignKey("dbo.OpdTherapyDetails", "PhysiotherapyId", "dbo.Physiotherapies");
            //DropIndex("dbo.OpdTherapyDetails", new[] { "PhysiotherapyId" });
            //DropIndex("dbo.OpdTherapyDetails", new[] { "OPDTherapyId" });
            //DropTable("dbo.OpdTherapyDetails");
            //DropTable("dbo.OPDTherapies");
        }
    }
}
