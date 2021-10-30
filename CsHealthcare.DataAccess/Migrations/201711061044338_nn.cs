namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeInfoes", "EducationId", c => c.Int());
            AddColumn("dbo.Educations", "Institution", c => c.String(maxLength: 100));
            AddColumn("dbo.Educations", "Grade", c => c.String(maxLength: 10));
            AddColumn("dbo.Educations", "CourseDuration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Educations", "Scale", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeInfoes", "EducationId");
            AddForeignKey("dbo.EmployeeInfoes", "EducationId", "dbo.Educations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeInfoes", "EducationId", "dbo.Educations");
            DropIndex("dbo.EmployeeInfoes", new[] { "EducationId" });
            DropColumn("dbo.Educations", "Scale");
            DropColumn("dbo.Educations", "CourseDuration");
            DropColumn("dbo.Educations", "Grade");
            DropColumn("dbo.Educations", "Institution");
            DropColumn("dbo.EmployeeInfoes", "EducationId");
        }
    }
}
