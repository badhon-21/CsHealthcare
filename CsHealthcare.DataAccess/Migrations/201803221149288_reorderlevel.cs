namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorderlevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreItems", "ReOrderLevel", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreItems", "ReOrderLevel");
        }
    }
}
