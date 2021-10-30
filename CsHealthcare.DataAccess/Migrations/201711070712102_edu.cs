namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeInfoes", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations");
            DropPrimaryKey("dbo.Educations");
            AlterColumn("dbo.Educations", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Educations", "Id");
            AddForeignKey("dbo.EmployeeInfoes", "EducationId", "dbo.Educations", "Id");
            AddForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations");
            DropForeignKey("dbo.EmployeeInfoes", "EducationId", "dbo.Educations");
            DropPrimaryKey("dbo.Educations");
            AlterColumn("dbo.Educations", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Educations", "Id");
            AddForeignKey("dbo.PatientInformations", "EducationId", "dbo.Educations", "Id");
            AddForeignKey("dbo.EmployeeInfoes", "EducationId", "dbo.Educations", "Id");
        }
    }
}
