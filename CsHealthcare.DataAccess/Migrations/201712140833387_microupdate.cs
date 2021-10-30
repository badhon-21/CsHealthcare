namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class microupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MicrobiologyTests", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.MicrobiologyTests", "OrganismIsolated", c => c.String());
            AddColumn("dbo.MicrobiologyTests", "ReferredBy", c => c.String());
            AddColumn("dbo.MicrobiologyTests", "Culture", c => c.String());
            AddColumn("dbo.MicrobiologyTests", "PatientAge", c => c.Int(nullable: false));
            CreateIndex("dbo.MicrobiologyTests", "PatientId");
            AddForeignKey("dbo.MicrobiologyTests", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MicrobiologyTests", "PatientId", "dbo.Patients");
            DropIndex("dbo.MicrobiologyTests", new[] { "PatientId" });
            DropColumn("dbo.MicrobiologyTests", "PatientAge");
            DropColumn("dbo.MicrobiologyTests", "Culture");
            DropColumn("dbo.MicrobiologyTests", "ReferredBy");
            DropColumn("dbo.MicrobiologyTests", "OrganismIsolated");
            DropColumn("dbo.MicrobiologyTests", "PatientId");
        }
    }
}
