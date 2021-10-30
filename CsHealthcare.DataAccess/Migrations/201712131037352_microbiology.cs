namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class microbiology : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MicrobiologyTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecimenId = c.Int(nullable: false),
                        Ampicillin = c.String(maxLength: 1),
                        Amoxycillin = c.String(maxLength: 1),
                        Amoxyclav = c.String(maxLength: 1),
                        Amikacin = c.String(maxLength: 1),
                        Azithromycin = c.String(maxLength: 1),
                        Carbinicillin = c.String(maxLength: 1),
                        Cefixime = c.String(maxLength: 1),
                        Cefotaxime = c.String(maxLength: 1),
                        Cefepime = c.String(maxLength: 1),
                        Ceftazidime = c.String(maxLength: 1),
                        Ceftiaxone = c.String(maxLength: 1),
                        Cephalexine = c.String(maxLength: 1),
                        Chloramphenicol = c.String(maxLength: 1),
                        Cloxacillin = c.String(maxLength: 1),
                        Colistin = c.String(maxLength: 1),
                        Cefuroxime = c.String(maxLength: 1),
                        Cephradine = c.String(maxLength: 1),
                        Ciprofloxacin = c.String(maxLength: 1),
                        Cotrimoxazole = c.String(maxLength: 1),
                        Doxycycline = c.String(maxLength: 1),
                        Erythromycin = c.String(maxLength: 1),
                        FusidicAcid = c.String(maxLength: 1),
                        Gentamycin = c.String(maxLength: 1),
                        Imipenem = c.String(maxLength: 1),
                        Meropenem = c.String(maxLength: 1),
                        NalidexicAcid = c.String(maxLength: 1),
                        Netilmycin = c.String(maxLength: 1),
                        Nitrofurantion = c.String(maxLength: 1),
                        Mecillinam = c.String(maxLength: 1),
                        Oxacillin = c.String(maxLength: 1),
                        Penicillin = c.String(maxLength: 1),
                        Rifampicin = c.String(maxLength: 1),
                        Tetracycline = c.String(maxLength: 1),
                        Tobramycin = c.String(maxLength: 1),
                        Vancomycin = c.String(maxLength: 1),
                        PiperacillinOrTazobactam = c.String(maxLength: 1),
                        Linezolid = c.String(maxLength: 1),
                        Doripenum = c.String(maxLength: 1),
                        Tigecycline = c.String(maxLength: 1),
                        Ticarcillin = c.String(maxLength: 1),
                        Clindamycin = c.String(maxLength: 1),
                        Levofloxacin = c.String(maxLength: 1),
                        Cepepime = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specimen", t => t.SpecimenId, cascadeDelete: true)
                .Index(t => t.SpecimenId);
            
            CreateTable(
                "dbo.Specimen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MicrobiologyTests", "SpecimenId", "dbo.Specimen");
            DropIndex("dbo.MicrobiologyTests", new[] { "SpecimenId" });
            DropTable("dbo.Specimen");
            DropTable("dbo.MicrobiologyTests");
        }
    }
}
