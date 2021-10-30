namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.TestRequests",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            TestNameId = c.Int(nullable: false),
            //            Notes = c.String(maxLength: 100),
            //            PatientInformationId = c.Int(nullable: false),
            //            CompletedBy = c.String(maxLength: 100),
            //            Department = c.String(maxLength: 100),
            //            Status = c.String(maxLength: 10),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.PatientInformations", t => t.PatientInformationId, cascadeDelete: true)
            //    .ForeignKey("dbo.Test_Name", t => t.TestNameId, cascadeDelete: true)
            //    .Index(t => t.TestNameId)
            //    .Index(t => t.PatientInformationId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.TestRequests", "TestNameId", "dbo.Test_Name");
            //DropForeignKey("dbo.TestRequests", "PatientInformationId", "dbo.PatientInformations");
            //DropIndex("dbo.TestRequests", new[] { "PatientInformationId" });
            //DropIndex("dbo.TestRequests", new[] { "TestNameId" });
            //DropTable("dbo.TestRequests");
        }
    }
}
