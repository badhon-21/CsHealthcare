namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conflictmigration2 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.PatientTestReportAttatchments",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientCode = c.String(),
            //            PatientId = c.Int(nullable: false),
            //            TestDate = c.DateTime(nullable: false),
            //            AttatchmentDate = c.DateTime(nullable: false),
            //            TestName = c.String(),
            //            FileName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.PatientTestReportAttatchments", "PatientId", "dbo.Patients");
            //DropIndex("dbo.PatientTestReportAttatchments", new[] { "PatientId" });
            //DropTable("dbo.PatientTestReportAttatchments");
        }
    }
}
