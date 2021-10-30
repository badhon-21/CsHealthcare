namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upemp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeInfoes", "MarriageDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeInfoes", "MarriageDate", c => c.DateTime(nullable: false));
        }
    }
}
