namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Patients", "Age", c => c.Int(nullable: false));
            //AlterColumn("dbo.Patients", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Patients", "DateOfBirth", c => c.DateTime(nullable: false));
            //DropColumn("dbo.Patients", "Age");
        }
    }
}
