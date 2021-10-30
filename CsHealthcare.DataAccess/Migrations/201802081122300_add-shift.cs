namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshift : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        MorningStart = c.String(maxLength: 20),
                        MorningEnd = c.String(maxLength: 20),
                        EveningStart = c.String(maxLength: 20),
                        EveningEnd = c.String(maxLength: 20),
                        NightStart = c.String(maxLength: 20),
                        NightEnd = c.String(maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EmployeeInfoes", "ShiftId", c => c.Int());
            AddColumn("dbo.EmployeeInfoes", "Badgenumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeInfoes", "Badgenumber");
            DropColumn("dbo.EmployeeInfoes", "ShiftId");
            DropTable("dbo.Shifts");
        }
    }
}
