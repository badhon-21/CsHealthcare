namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullpriceupdateondepartmentwisestockoutdetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DrugDepartmentWiseStockOutDetails", "SubTotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DrugDepartmentWiseStockOutDetails", "SubTotalPrice", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
