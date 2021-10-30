namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrugStockIns", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DrugStockIns", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.DrugStockIns", "CreatedBy", c => c.String());
            AddColumn("dbo.DrugStockIns", "ModifiedBy", c => c.String());
            AddColumn("dbo.DrugStockIns", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugStockIns", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockIns", "RecStatus", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockIns", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DrugDepartmentWiseStockIns", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.DrugDepartmentWiseStockIns", "CreatedBy", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockIns", "ModifiedBy", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockIns", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockIns", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockOuts", "RecStatus", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockOuts", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DrugDepartmentWiseStockOuts", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.DrugDepartmentWiseStockOuts", "CreatedBy", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockOuts", "ModifiedBy", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockOuts", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.DrugDepartmentWiseStockOuts", "ModifiedIpAddress", c => c.String());
            AddColumn("dbo.PurchaseOrders", "RecStatus", c => c.String());
            AddColumn("dbo.PurchaseOrders", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseOrders", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "CreatedBy", c => c.String());
            AddColumn("dbo.PurchaseOrders", "ModifiedBy", c => c.String());
            AddColumn("dbo.PurchaseOrders", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.PurchaseOrders", "ModifiedIpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "ModifiedIpAddress");
            DropColumn("dbo.PurchaseOrders", "CreatedIpAddress");
            DropColumn("dbo.PurchaseOrders", "ModifiedBy");
            DropColumn("dbo.PurchaseOrders", "CreatedBy");
            DropColumn("dbo.PurchaseOrders", "ModifiedDate");
            DropColumn("dbo.PurchaseOrders", "CreatedDate");
            DropColumn("dbo.PurchaseOrders", "RecStatus");
            DropColumn("dbo.DrugDepartmentWiseStockOuts", "ModifiedIpAddress");
            DropColumn("dbo.DrugDepartmentWiseStockOuts", "CreatedIpAddress");
            DropColumn("dbo.DrugDepartmentWiseStockOuts", "ModifiedBy");
            DropColumn("dbo.DrugDepartmentWiseStockOuts", "CreatedBy");
            DropColumn("dbo.DrugDepartmentWiseStockOuts", "ModifiedDate");
            DropColumn("dbo.DrugDepartmentWiseStockOuts", "CreatedDate");
            DropColumn("dbo.DrugDepartmentWiseStockOuts", "RecStatus");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "ModifiedIpAddress");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "CreatedIpAddress");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "ModifiedBy");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "CreatedBy");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "ModifiedDate");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "CreatedDate");
            DropColumn("dbo.DrugDepartmentWiseStockIns", "RecStatus");
            DropColumn("dbo.DrugStockIns", "ModifiedIpAddress");
            DropColumn("dbo.DrugStockIns", "CreatedIpAddress");
            DropColumn("dbo.DrugStockIns", "ModifiedBy");
            DropColumn("dbo.DrugStockIns", "CreatedBy");
            DropColumn("dbo.DrugStockIns", "ModifiedDate");
            DropColumn("dbo.DrugStockIns", "CreatedDate");
        }
    }
}
