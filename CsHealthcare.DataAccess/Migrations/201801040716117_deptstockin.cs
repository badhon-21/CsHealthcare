namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deptstockin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentDetailsForItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemoNo = c.String(maxLength: 50),
                        DepartmentId = c.String(maxLength: 128),
                        StockOutItemId = c.Int(nullable: false),
                        TotalQty = c.Decimal(precision: 18, scale: 2),
                        RemainingQuantity = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DEPARTMENTs", t => t.DepartmentId)
                .ForeignKey("dbo.StockOutItems", t => t.StockOutItemId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.StockOutItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentDetailsForItems", "StockOutItemId", "dbo.StockOutItems");
            DropForeignKey("dbo.DepartmentDetailsForItems", "DepartmentId", "dbo.DEPARTMENTs");
            DropIndex("dbo.DepartmentDetailsForItems", new[] { "StockOutItemId" });
            DropIndex("dbo.DepartmentDetailsForItems", new[] { "DepartmentId" });
            DropTable("dbo.DepartmentDetailsForItems");
        }
    }
}
