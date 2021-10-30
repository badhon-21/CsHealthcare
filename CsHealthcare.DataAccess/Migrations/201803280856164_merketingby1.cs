namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merketingby1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MerketingBies", "RecStatus", c => c.String());
            AddColumn("dbo.MerketingBies", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MerketingBies", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.MerketingBies", "CreatedBy", c => c.String());
            AddColumn("dbo.MerketingBies", "ModifiedBy", c => c.String());
            AddColumn("dbo.MerketingBies", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.MerketingBies", "ModifiedIpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MerketingBies", "ModifiedIpAddress");
            DropColumn("dbo.MerketingBies", "CreatedIpAddress");
            DropColumn("dbo.MerketingBies", "ModifiedBy");
            DropColumn("dbo.MerketingBies", "CreatedBy");
            DropColumn("dbo.MerketingBies", "ModifiedDate");
            DropColumn("dbo.MerketingBies", "CreatedDate");
            DropColumn("dbo.MerketingBies", "RecStatus");
        }
    }
}
