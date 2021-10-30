namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedue : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OpdTherapyDueCollections", "PatientId");
            DropColumn("dbo.OpdTherapyDueCollections", "RecStatus");
            DropColumn("dbo.OpdTherapyDueCollections", "CreatedDate");
            DropColumn("dbo.OpdTherapyDueCollections", "ModifiedDate");
            DropColumn("dbo.OpdTherapyDueCollections", "ModifiedBy");
            DropColumn("dbo.OpdTherapyDueCollections", "CreatedIpAddress");
            DropColumn("dbo.OpdTherapyDueCollections", "ModifiedIpAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OpdTherapyDueCollections", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.OpdTherapyDueCollections", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.OpdTherapyDueCollections", "ModifiedBy", c => c.String());
            AddColumn("dbo.OpdTherapyDueCollections", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.OpdTherapyDueCollections", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OpdTherapyDueCollections", "RecStatus", c => c.String());
            AddColumn("dbo.OpdTherapyDueCollections", "PatientId", c => c.String());
        }
    }
}
