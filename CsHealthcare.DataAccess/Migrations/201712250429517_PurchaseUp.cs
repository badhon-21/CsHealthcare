namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "RecordDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "RecordDate");
        }
    }
}
