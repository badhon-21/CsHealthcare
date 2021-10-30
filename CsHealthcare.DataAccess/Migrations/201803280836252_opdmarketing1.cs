namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opdmarketing1 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.OptPatientBills", "MarketingBy", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.OptPatientBills", "MarketingBy");
        }
    }
}
