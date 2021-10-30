namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reconflict : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.MerketingBies",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(maxLength: 100),
            //            Designation = c.String(),
            //            RecStatus = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //            ModifiedDate = c.DateTime(),
            //            CreatedBy = c.String(),
            //            ModifiedBy = c.String(),
            //            CreatedIpAddress = c.String(),
            //            ModifiedIpAddress = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.OptPatientBills", "MarketingBy", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.OptPatientBills", "MarketingBy");
            //DropTable("dbo.MerketingBies");
        }
    }
}
