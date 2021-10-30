namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requantity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StoreRequisitionDetails", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StoreRequisitionDetails", "Quantity", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
