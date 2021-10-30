namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lcvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LCs", "LCValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LCs", "LCValue");
        }
    }
}
