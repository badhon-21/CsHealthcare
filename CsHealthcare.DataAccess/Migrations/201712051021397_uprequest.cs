namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uprequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestRequests", "Status", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestRequests", "Status");
        }
    }
}
