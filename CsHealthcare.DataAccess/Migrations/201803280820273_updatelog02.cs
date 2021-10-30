namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelog02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientCards", "RecStatus", c => c.String());
            AddColumn("dbo.PatientCards", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.PatientCards", "CreatedBy", c => c.String());
            AddColumn("dbo.PatientCards", "ModifiedBy", c => c.String());
            AddColumn("dbo.PatientCards", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PatientCards", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PatientDueCollections", "PatientId", c => c.String());
            AddColumn("dbo.PatientDueCollections", "VoucherNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientDueCollections", "VoucherNo");
            DropColumn("dbo.PatientDueCollections", "PatientId");
            DropColumn("dbo.PatientCards", "ModifiedIpAddress");
            DropColumn("dbo.PatientCards", "CreatedIpAddress");
            DropColumn("dbo.PatientCards", "ModifiedBy");
            DropColumn("dbo.PatientCards", "CreatedBy");
            DropColumn("dbo.PatientCards", "ModifiedDate");
            DropColumn("dbo.PatientCards", "RecStatus");
        }
    }
}
