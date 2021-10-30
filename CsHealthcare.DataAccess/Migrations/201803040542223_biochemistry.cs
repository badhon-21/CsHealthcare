namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class biochemistry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BioChemistries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(maxLength: 100),
                        ReferanceName = c.String(maxLength: 50),
                        SpecimenName = c.String(),
                        BloodGlucoseRandom = c.String(),
                        BloodGlucoseFasting = c.String(),
                        Twohrsafter75gmGlucose = c.String(),
                        BloodGlucoseTwohrsABF = c.String(),
                        Urea = c.String(),
                        SCreatinine = c.String(),
                        SUricAcid = c.String(),
                        SAST = c.String(),
                        SALT = c.String(),
                        SAlkalinePhosphatase = c.String(),
                        SAlkalinePhosphataseProtein = c.String(),
                        SCalcium = c.String(),
                        SIron = c.String(),
                        STIBC = c.String(),
                        SInorganicPhosphate = c.String(),
                        SMagnesium = c.String(),
                        Sodium = c.String(),
                        Potassium = c.String(),
                        Chloride = c.String(),
                        TotalCarbondioxaid = c.String(),
                        SCholesterol = c.String(),
                        STriglycerides = c.String(),
                        SHDLCholesterol = c.String(),
                        TroponinI = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.ENDOCRINOLOGies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(maxLength: 100),
                        ReferanceName = c.String(maxLength: 50),
                        SpecimenName = c.String(),
                        T3 = c.String(),
                        T4 = c.String(),
                        TSH = c.String(),
                        FreeT3 = c.String(),
                        FreeT4 = c.String(),
                        FSH = c.String(),
                        LH = c.String(),
                        Prolactin = c.String(),
                        STestosterone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.IMMUNOLOGICALs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(maxLength: 100),
                        ReferanceName = c.String(maxLength: 50),
                        SpecimenName = c.String(),
                        βhCG = c.String(),
                        PSA = c.String(),
                        SFerritin = c.String(),
                        TIgE = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.SEROLOGies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientCode = c.String(maxLength: 100),
                        ReferanceName = c.String(maxLength: 50),
                        SpecimenName = c.String(),
                        CRP = c.String(),
                        RA = c.String(),
                        ASO = c.String(),
                        HBsAg = c.String(),
                        BloodGroup = c.String(),
                        RhFactor = c.String(),
                        UrineforPregnancyTest = c.String(),
                        VDRL = c.String(),
                        TO = c.String(),
                        TH = c.String(),
                        AH = c.String(),
                        BH = c.String(),
                        AO = c.String(),
                        BO = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SEROLOGies", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.IMMUNOLOGICALs", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.ENDOCRINOLOGies", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.BioChemistries", "PatientId", "dbo.Patients");
            DropIndex("dbo.SEROLOGies", new[] { "PatientId" });
            DropIndex("dbo.IMMUNOLOGICALs", new[] { "PatientId" });
            DropIndex("dbo.ENDOCRINOLOGies", new[] { "PatientId" });
            DropIndex("dbo.BioChemistries", new[] { "PatientId" });
            DropTable("dbo.SEROLOGies");
            DropTable("dbo.IMMUNOLOGICALs");
            DropTable("dbo.ENDOCRINOLOGies");
            DropTable("dbo.BioChemistries");
        }
    }
}
