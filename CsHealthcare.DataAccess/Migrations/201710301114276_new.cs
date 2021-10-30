namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmergencyContacts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RefferenceId = c.String(maxLength: 50),
                        ContactName1 = c.String(maxLength: 50),
                        Relationship1 = c.String(maxLength: 50),
                        Address1 = c.String(maxLength: 200),
                        Homephone1 = c.String(maxLength: 50),
                        Workphone1 = c.String(maxLength: 50),
                        Cellphone1 = c.String(maxLength: 50),
                        ContactName2 = c.String(maxLength: 50),
                        Relationship2 = c.String(maxLength: 50),
                        Address2 = c.String(maxLength: 200),
                        Homephone2 = c.String(maxLength: 50),
                        Workphone2 = c.String(maxLength: 50),
                        Cellphone2 = c.String(maxLength: 50),
                        PhysicianName = c.String(maxLength: 50),
                        PhysicianAddress = c.String(maxLength: 200),
                        PhysicianContactNo = c.String(maxLength: 50),
                        RefferenceType = c.String(maxLength: 2),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EmployeeInfoes", "RecStatus", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployeeInfoes", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.EmployeeInfoes", "CreatedBy", c => c.String());
            AddColumn("dbo.EmployeeInfoes", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeInfoes", "ModifiedBy");
            DropColumn("dbo.EmployeeInfoes", "CreatedBy");
            DropColumn("dbo.EmployeeInfoes", "ModifiedDate");
            DropColumn("dbo.EmployeeInfoes", "CreatedDate");
            DropColumn("dbo.EmployeeInfoes", "RecStatus");
            DropTable("dbo.EmergencyContacts");
        }
    }
}
