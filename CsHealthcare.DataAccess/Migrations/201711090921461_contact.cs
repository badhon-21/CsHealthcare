namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmergencyContacts", "EmployeeInfoId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EmergencyContacts", "EmployeeInfoId");
            AddForeignKey("dbo.EmergencyContacts", "EmployeeInfoId", "dbo.EmployeeInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmergencyContacts", "EmployeeInfoId", "dbo.EmployeeInfoes");
            DropIndex("dbo.EmergencyContacts", new[] { "EmployeeInfoId" });
            DropColumn("dbo.EmergencyContacts", "EmployeeInfoId");
        }
    }
}
