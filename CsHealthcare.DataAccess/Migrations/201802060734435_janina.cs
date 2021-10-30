namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class janina : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DrugDepartmentWiseStockOuts", "TotalQty", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DrugDepartmentWiseStockOuts", "TotalQty", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
