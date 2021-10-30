namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ward : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WardTypeId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                        PriceByDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WardTypes", t => t.WardTypeId, cascadeDelete: true)
                .Index(t => t.WardTypeId);
            
            CreateTable(
                "dbo.WardTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Status = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wards", "WardTypeId", "dbo.WardTypes");
            DropIndex("dbo.Wards", new[] { "WardTypeId" });
            DropTable("dbo.WardTypes");
            DropTable("dbo.Wards");
        }
    }
}
