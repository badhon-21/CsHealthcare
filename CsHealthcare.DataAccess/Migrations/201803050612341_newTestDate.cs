namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTestDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BioChemistries", "Department", c => c.String());
            AddColumn("dbo.BioChemistries", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ENDOCRINOLOGies", "Department", c => c.String());
            AddColumn("dbo.ENDOCRINOLOGies", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.IMMUNOLOGICALs", "Department", c => c.String());
            AddColumn("dbo.IMMUNOLOGICALs", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.SEROLOGies", "Department", c => c.String());
            AddColumn("dbo.SEROLOGies", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SEROLOGies", "Date");
            DropColumn("dbo.SEROLOGies", "Department");
            DropColumn("dbo.IMMUNOLOGICALs", "Date");
            DropColumn("dbo.IMMUNOLOGICALs", "Department");
            DropColumn("dbo.ENDOCRINOLOGies", "Date");
            DropColumn("dbo.ENDOCRINOLOGies", "Department");
            DropColumn("dbo.BioChemistries", "Date");
            DropColumn("dbo.BioChemistries", "Department");
        }
    }
}
