namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cabinstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CabinRents", "Status", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CabinRents", "Status");
        }
    }
}
