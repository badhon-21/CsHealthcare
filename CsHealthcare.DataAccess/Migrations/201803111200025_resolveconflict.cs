namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resolveconflict : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.OPDTherapies", "MarketingBy", c => c.String(maxLength: 200));
            //AddColumn("dbo.OPDTherapies", "Status", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.OPDTherapies", "Status");
            //DropColumn("dbo.OPDTherapies", "MarketingBy");
        }
    }
}
