namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RETests", "Albumin", c => c.String());
            AddColumn("dbo.RETests", "Ketones", c => c.String());
            AddColumn("dbo.RETests", "Puscells", c => c.String());
            AddColumn("dbo.RETests", "Crystals", c => c.String());
            AddColumn("dbo.RETests", "Others", c => c.String());
            DropColumn("dbo.RETests", "KetoneBody");
            DropColumn("dbo.RETests", "Pluscells");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RETests", "Pluscells", c => c.String());
            AddColumn("dbo.RETests", "KetoneBody", c => c.String());
            DropColumn("dbo.RETests", "Others");
            DropColumn("dbo.RETests", "Crystals");
            DropColumn("dbo.RETests", "Puscells");
            DropColumn("dbo.RETests", "Ketones");
            DropColumn("dbo.RETests", "Albumin");
        }
    }
}
