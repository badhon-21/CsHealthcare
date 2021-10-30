namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattendancetable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendenceTemps", "Remarks", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AttendenceTemps", "Remarks");
        }
    }
}
