namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDialysistable3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DialysisPayments", "PatientId", "dbo.PatientInformations");
            DropIndex("dbo.DialysisPayments", new[] { "PatientId" });
            CreateTable(
                "dbo.PatientEnrollDialysis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNo = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(maxLength: 30),
                        Type = c.String(maxLength: 20),
                        Status = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientInformations", t => t.PatientId)
                .Index(t => t.PatientId);
            
            AddColumn("dbo.DialysisPayments", "PatientDialysisEnrollId", c => c.Int(nullable: false));
            CreateIndex("dbo.DialysisPayments", "PatientDialysisEnrollId");
            AddForeignKey("dbo.DialysisPayments", "PatientDialysisEnrollId", "dbo.PatientEnrollDialysis", "Id");
            DropColumn("dbo.DialysisPayments", "PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DialysisPayments", "PatientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PatientEnrollDialysis", "PatientId", "dbo.PatientInformations");
            DropForeignKey("dbo.DialysisPayments", "PatientDialysisEnrollId", "dbo.PatientEnrollDialysis");
            DropIndex("dbo.DialysisPayments", new[] { "PatientDialysisEnrollId" });
            DropIndex("dbo.PatientEnrollDialysis", new[] { "PatientId" });
            DropColumn("dbo.DialysisPayments", "PatientDialysisEnrollId");
            DropTable("dbo.PatientEnrollDialysis");
            CreateIndex("dbo.DialysisPayments", "PatientId");
            AddForeignKey("dbo.DialysisPayments", "PatientId", "dbo.PatientInformations", "Id");
        }
    }
}
