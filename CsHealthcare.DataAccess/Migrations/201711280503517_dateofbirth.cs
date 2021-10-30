namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateofbirth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "DateOfBirth", c => c.DateTime());
        }
    }
}
