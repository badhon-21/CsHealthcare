namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RETests", "Turbidity", c => c.String());
            AddColumn("dbo.RETests", "Sediment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RETests", "Sediment");
            DropColumn("dbo.RETests", "Turbidity");
        }
    }
}
