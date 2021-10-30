namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattendancetable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendenceCheckInOuts", "Remarks", c => c.String(maxLength: 50));
            DropColumn("dbo.AttendenceTemps", "Remarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttendenceTemps", "Remarks", c => c.String(maxLength: 50));
            DropColumn("dbo.AttendenceCheckInOuts", "Remarks");
        }
    }
}
