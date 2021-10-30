namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RETests", "Blood", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RETests", "Blood");
        }
    }
}
