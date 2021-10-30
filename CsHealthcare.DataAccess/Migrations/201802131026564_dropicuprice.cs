namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropicuprice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ICUs", "PriceByDay");
            DropColumn("dbo.ICUs", "PriceByHour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ICUs", "PriceByHour", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ICUs", "PriceByDay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
