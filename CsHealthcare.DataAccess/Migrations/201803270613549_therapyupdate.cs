namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class therapyupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDTherapies", "RecStatus", c => c.String());
            AddColumn("dbo.OPDTherapies", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.OPDTherapies", "CreatedBy", c => c.String());
            AddColumn("dbo.OPDTherapies", "ModifiedBy", c => c.String());
            AddColumn("dbo.OPDTherapies", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.OPDTherapies", "ModifiedIpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OPDTherapies", "ModifiedIpAddress");
            DropColumn("dbo.OPDTherapies", "CreatedIpAddress");
            DropColumn("dbo.OPDTherapies", "ModifiedBy");
            DropColumn("dbo.OPDTherapies", "CreatedBy");
            DropColumn("dbo.OPDTherapies", "ModifiedDate");
            DropColumn("dbo.OPDTherapies", "RecStatus");
        }
    }
}
