namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugStockDetails", "SubTotalPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.DrugStockDetails", "SalePrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.DrugStockDetails", "CostTotalPrice");
            DropColumn("dbo.DrugStockDetails", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrugStockDetails", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.DrugStockDetails", "CostTotalPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.DrugStockDetails", "SalePrice");
            DropColumn("dbo.DrugStockDetails", "SubTotalPrice");
        }
    }
}
