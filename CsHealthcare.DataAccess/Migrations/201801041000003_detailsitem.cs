namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailsitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DepartmentDetailsForItems", "DepartmentName", c => c.String());
            AddColumn("dbo.DepartmentDetailsForItems", "StockOutItemName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DepartmentDetailsForItems", "StockOutItemName");
            DropColumn("dbo.DepartmentDetailsForItems", "DepartmentName");
        }
    }
}
