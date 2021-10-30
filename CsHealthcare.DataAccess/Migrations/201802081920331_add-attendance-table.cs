namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattendancetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendenceCheckInOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpId = c.String(maxLength: 50),
                        ChkInTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttendenceTemps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 50),
                        Badgenumber = c.String(maxLength: 50),
                        CheckInTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AttendenceTemps");
            DropTable("dbo.AttendenceCheckInOuts");
        }
    }
}
