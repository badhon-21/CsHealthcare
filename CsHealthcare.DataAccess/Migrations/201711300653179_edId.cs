namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PatientInformations", name: "EducationId", newName: "Education_Id");
            RenameIndex(table: "dbo.PatientInformations", name: "IX_EducationId", newName: "IX_Education_Id");
            AddColumn("dbo.PatientInformations", "PatientEducationId", c => c.Int());
            CreateIndex("dbo.PatientInformations", "PatientEducationId");
            AddForeignKey("dbo.PatientInformations", "PatientEducationId", "dbo.PatientEducations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientInformations", "PatientEducationId", "dbo.PatientEducations");
            DropIndex("dbo.PatientInformations", new[] { "PatientEducationId" });
            DropColumn("dbo.PatientInformations", "PatientEducationId");
            RenameIndex(table: "dbo.PatientInformations", name: "IX_Education_Id", newName: "IX_EducationId");
            RenameColumn(table: "dbo.PatientInformations", name: "Education_Id", newName: "EducationId");
        }
    }
}
