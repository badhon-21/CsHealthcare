namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shift : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShiftInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Title = c.String(maxLength: 50),
                        Type = c.String(maxLength: 20),
                        StartDay = c.String(maxLength: 50),
                        DayOn = c.Int(),
                        DayOff = c.Int(),
                        StartTime = c.String(maxLength: 50),
                        WorkingHour = c.String(maxLength: 50),
                        EndTime = c.String(maxLength: 50),
                        HasLunchDinner = c.Boolean(nullable: false),
                        BeginTime = c.String(maxLength: 50),
                        Duration = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShiftInfoes");
        }
    }
}
