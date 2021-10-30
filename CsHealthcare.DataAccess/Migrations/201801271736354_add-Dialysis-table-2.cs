namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDialysistable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientDialysis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        MachinNumber = c.String(),
                        ConsultantName = c.String(),
                        ConsultantContactNumber = c.String(),
                        NoOfTakenDialysis = c.Int(),
                        LastDialysisTakenHospital = c.String(),
                        Hemoglobin = c.Decimal(precision: 18, scale: 2),
                        LastWeight = c.Decimal(precision: 18, scale: 2),
                        PreDialysisBodyWeight = c.String(),
                        PreDialysisBodyBP = c.String(),
                        PreDialysisBodyPulse = c.String(),
                        PreDialysisBodyResp = c.String(),
                        PreDialysisBodyTemp = c.String(),
                        PostDialysisBodyWeight = c.String(),
                        PostDialysisBodyBP = c.String(),
                        PostDialysisBodyPulse = c.String(),
                        PostDialysisBodyResp = c.String(),
                        PostDialysisBodyTemp = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientDialysis", "PatientId", "dbo.PatientInformations");
            DropIndex("dbo.PatientDialysis", new[] { "PatientId" });
            DropTable("dbo.PatientDialysis");
        }
    }
}
