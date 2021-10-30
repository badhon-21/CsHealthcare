namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestRequests", "PatientInformationId", "dbo.PatientInformations");
            DropIndex("dbo.TestRequests", new[] { "PatientInformationId" });
            RenameColumn(table: "dbo.TestRequests", name: "TestNameId", newName: "Test_NameId");
            RenameIndex(table: "dbo.TestRequests", name: "IX_TestNameId", newName: "IX_Test_NameId");
            AddColumn("dbo.TestRequests", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.TestRequests", "PatientId");
            AddForeignKey("dbo.TestRequests", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            DropColumn("dbo.TestRequests", "PatientInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestRequests", "PatientInformationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TestRequests", "PatientId", "dbo.Patients");
            DropIndex("dbo.TestRequests", new[] { "PatientId" });
            DropColumn("dbo.TestRequests", "PatientId");
            RenameIndex(table: "dbo.TestRequests", name: "IX_Test_NameId", newName: "IX_TestNameId");
            RenameColumn(table: "dbo.TestRequests", name: "Test_NameId", newName: "TestNameId");
            CreateIndex("dbo.TestRequests", "PatientInformationId");
            AddForeignKey("dbo.TestRequests", "PatientInformationId", "dbo.PatientInformations", "Id", cascadeDelete: true);
        }
    }
}
