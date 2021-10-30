namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qq : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.CBCTests",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(nullable: false),
            //            Haemoglobin = c.String(),
            //            Hematocrit = c.String(),
            //            RedCellsCount = c.String(),
            //            MeanCellVolume = c.String(),
            //            MeanCellHaemoglobin = c.String(),
            //            MeanCellHaemoglobinConcentration = c.String(),
            //            RedCellDistributionWidth = c.String(),
            //            NucleatedRedBloodCells = c.String(),
            //            TotalWbcCount = c.String(),
            //            Neutrophil = c.String(),
            //            Lymphocyte = c.String(),
            //            Monocyte = c.String(),
            //            Eosinophil = c.String(),
            //            Basophil = c.String(),
            //            ImmatureGranulocytes = c.String(),
            //            Neutrophils = c.String(),
            //            Lymphocytes = c.String(),
            //            Monocytes = c.String(),
            //            Eosinophils = c.String(),
            //            Basophils = c.String(),
            //            ImmatureGranulocytess = c.String(),
            //            PlateletsCount = c.String(),
            //            ErythrocyteSedimentationRate = c.String(),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId);
            
            //CreateTable(
            //    "dbo.RETests",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(nullable: false),
            //            Colour = c.String(),
            //            Clarity = c.String(),
            //            Specificgravity = c.String(),
            //            PH = c.String(),
            //            Protein = c.String(),
            //            Glucose = c.String(),
            //            KetoneBody = c.String(),
            //            Bilirubin = c.String(),
            //            Urobilinogen = c.String(),
            //            Nitrite = c.String(),
            //            Pluscells = c.String(),
            //            EpithelialCells = c.String(),
            //            RedBloodCell = c.String(),
            //            HyalineCast = c.String(),
            //            GranularCast = c.String(),
            //            WbcCast = c.String(),
            //            RbcCast = c.String(),
            //            CalciumOxalate = c.String(),
            //            UricAcid = c.String(),
            //            TriplePhosphate = c.String(),
            //            Amorphosphate = c.String(),
            //            YeastCandida = c.String(),
            //            TrichomonasVaginalis = c.String(),
            //            Spermatozoa = c.String(),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId);
            
            //CreateTable(
            //    "dbo.SRETests",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PatientId = c.Int(nullable: false),
            //            Colour = c.String(),
            //            Consistency = c.String(),
            //            Mucus = c.String(),
            //            Blood = c.String(),
            //            Reaction = c.String(),
            //            ReducingSubstance = c.String(),
            //            OccultBloodTest = c.String(),
            //            PusCells = c.String(),
            //            RedBloodCells = c.String(),
            //            Macrophage = c.String(),
            //            VegetableCells = c.String(),
            //            StarchGranules = c.String(),
            //            MuscleFibres = c.String(),
            //            FatGlobules = c.String(),
            //            Ova = c.String(),
            //            Protozoa = c.String(),
            //            Cysts = c.String(),
            //            Others = c.String(),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
            //    .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.SRETests", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.RETests", "PatientId", "dbo.Patients");
            //DropForeignKey("dbo.CBCTests", "PatientId", "dbo.Patients");
            //DropIndex("dbo.SRETests", new[] { "PatientId" });
            //DropIndex("dbo.RETests", new[] { "PatientId" });
            //DropIndex("dbo.CBCTests", new[] { "PatientId" });
            //DropTable("dbo.SRETests");
            //DropTable("dbo.RETests");
            //DropTable("dbo.CBCTests");
        }
    }
}
