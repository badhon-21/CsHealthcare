namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newlc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LCs", "LCValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LCs", "LCValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
