namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cbc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CBCTests", "PlateletsCount", c => c.String());
            AddColumn("dbo.CBCTests", "ErythrocyteSedimentationRate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CBCTests", "ErythrocyteSedimentationRate");
            DropColumn("dbo.CBCTests", "PlateletsCount");
        }
    }
}
