namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uptest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RETests", "UricAcid", c => c.String());
            AddColumn("dbo.RETests", "TriplePhosphate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RETests", "TriplePhosphate");
            DropColumn("dbo.RETests", "UricAcid");
        }
    }
}
