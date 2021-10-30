namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specimen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CBCTests", "SpecimenName", c => c.String());
            AddColumn("dbo.RETests", "SpecimenName", c => c.String());
            AddColumn("dbo.SRETests", "SpecimenName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SRETests", "SpecimenName");
            DropColumn("dbo.RETests", "SpecimenName");
            DropColumn("dbo.CBCTests", "SpecimenName");
        }
    }
}
