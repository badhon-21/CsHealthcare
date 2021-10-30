namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PharmacyRequisitions", "RequisitionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StockOutItems", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockOutItems", "Date", c => c.DateTime());
            AlterColumn("dbo.PharmacyRequisitions", "RequisitionDate", c => c.DateTime());
        }
    }
}
