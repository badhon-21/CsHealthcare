namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class marketingbyonpatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "MarketingBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "MarketingBy");
        }
    }
}
