namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class micro1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MicrobiologyTests", "SpecimenId", "dbo.Specimen");
            DropIndex("dbo.MicrobiologyTests", new[] { "SpecimenId" });
            AddColumn("dbo.MicrobiologyTests", "SpecimenName", c => c.String());
            DropColumn("dbo.MicrobiologyTests", "SpecimenId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MicrobiologyTests", "SpecimenId", c => c.Int(nullable: false));
            DropColumn("dbo.MicrobiologyTests", "SpecimenName");
            CreateIndex("dbo.MicrobiologyTests", "SpecimenId");
            AddForeignKey("dbo.MicrobiologyTests", "SpecimenId", "dbo.Specimen", "Id", cascadeDelete: true);
        }
    }
}
