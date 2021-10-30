namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestCodeAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Test_Name", "T_CODE", c => c.String(maxLength: 50));
            AddColumn("dbo.TEST_CATEGORY", "TC_CODE", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TEST_CATEGORY", "TC_CODE");
            DropColumn("dbo.Test_Name", "T_CODE");
        }
    }
}
