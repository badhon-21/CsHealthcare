namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class givenamount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OptPatientBills", "GivenAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OptPatientBills", "GivenAmount");
        }
    }
}
