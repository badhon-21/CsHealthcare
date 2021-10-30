namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcnflictup : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.PatientCards",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientCode = c.String(),
            //            PatientName = c.String(),
            //            FatherName = c.String(maxLength: 100),
            //            MotherName = c.String(maxLength: 100),
            //            ReferanceName = c.String(maxLength: 50),
            //            Age = c.Int(nullable: false),
            //            BloodGroup = c.String(maxLength: 20),
            //            Address = c.String(maxLength: 200),
            //            Sex = c.String(maxLength: 20),
            //            OccupationId = c.Int(),
            //            EducationId = c.Int(),
            //            MobileNumber = c.String(maxLength: 20),
            //            RegistrationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            VoucherNo = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.BioChemistries", "Department", c => c.String());
            //AddColumn("dbo.BioChemistries", "Date", c => c.DateTime(nullable: false));
            //AddColumn("dbo.ENDOCRINOLOGies", "Department", c => c.String());
            //AddColumn("dbo.ENDOCRINOLOGies", "Date", c => c.DateTime(nullable: false));
            //AddColumn("dbo.IMMUNOLOGICALs", "Department", c => c.String());
            //AddColumn("dbo.IMMUNOLOGICALs", "Date", c => c.DateTime(nullable: false));
            //AddColumn("dbo.SEROLOGies", "Department", c => c.String());
            //AddColumn("dbo.SEROLOGies", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.SEROLOGies", "Date");
            //DropColumn("dbo.SEROLOGies", "Department");
            //DropColumn("dbo.IMMUNOLOGICALs", "Date");
            //DropColumn("dbo.IMMUNOLOGICALs", "Department");
            //DropColumn("dbo.ENDOCRINOLOGies", "Date");
            //DropColumn("dbo.ENDOCRINOLOGies", "Department");
            //DropColumn("dbo.BioChemistries", "Date");
            //DropColumn("dbo.BioChemistries", "Department");
            //DropTable("dbo.PatientCards");
        }
    }
}
