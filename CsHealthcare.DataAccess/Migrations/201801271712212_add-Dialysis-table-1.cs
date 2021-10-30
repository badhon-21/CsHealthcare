namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDialysistable1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Wards", "WardTypeId", "dbo.WardTypes");
            //DropIndex("dbo.Wards", new[] { "WardTypeId" });
            CreateTable(
                "dbo.DialysisPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        VisitNo = c.Int(),
                        MsDialysisAmountPurposeId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        Reason = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MsDialysisAmountPurposes", t => t.MsDialysisAmountPurposeId)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.MsDialysisAmountPurposeId);
            
            CreateTable(
                "dbo.MsDialysisAmountPurposes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 250),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Type = c.String(maxLength: 10),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //DropColumn("dbo.Wards", "WardTypeId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Wards", "WardTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DialysisPayments", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.DialysisPayments", "MsDialysisAmountPurposeId", "dbo.MsDialysisAmountPurposes");
            DropIndex("dbo.DialysisPayments", new[] { "MsDialysisAmountPurposeId" });
            DropIndex("dbo.DialysisPayments", new[] { "PatientId" });
            DropTable("dbo.MsDialysisAmountPurposes");
            DropTable("dbo.DialysisPayments");
            //CreateIndex("dbo.Wards", "WardTypeId");
            //AddForeignKey("dbo.Wards", "WardTypeId", "dbo.WardTypes", "Id", cascadeDelete: true);
        }
    }
}
