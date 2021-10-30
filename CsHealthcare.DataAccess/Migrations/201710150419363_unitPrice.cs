namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unitPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugStockDetails", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DrugStockDetails", "UnitPrice");
        }
    }
}
