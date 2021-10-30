namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshift1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeInfoes", "ShiftId", c => c.Int(nullable: true));
            CreateIndex("dbo.EmployeeInfoes", "ShiftId");
            AddForeignKey("dbo.EmployeeInfoes", "ShiftId", "dbo.Shifts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeInfoes", "ShiftId", "dbo.Shifts");
            DropIndex("dbo.EmployeeInfoes", new[] { "ShiftId" });
            AlterColumn("dbo.EmployeeInfoes", "ShiftId", c => c.Int());
        }
    }
}
