namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AttendenceCheckInOuts", newName: "EmployeeAttendenceCheckInOuts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EmployeeAttendenceCheckInOuts", newName: "AttendenceCheckInOuts");
        }
    }
}
