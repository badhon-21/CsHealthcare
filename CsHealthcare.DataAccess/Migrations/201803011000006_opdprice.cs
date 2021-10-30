namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opdprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDTherapies", "TotalPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OPDTherapies", "TotalPrice");
        }
    }
}
