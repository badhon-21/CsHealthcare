namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newedu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "Year", c => c.String(maxLength: 4));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Educations", "Year");
        }
    }
}
