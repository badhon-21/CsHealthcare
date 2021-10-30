namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestRequests", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestRequests", "Status", c => c.String(maxLength: 10));
        }
    }
}
