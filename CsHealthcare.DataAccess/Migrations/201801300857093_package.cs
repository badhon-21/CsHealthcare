namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class package : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PackageDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PackageId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackageExcludes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageId = c.Int(nullable: false),
                        Excludes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .Index(t => t.PackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackageExcludes", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.PackageDetails", "PackageId", "dbo.Packages");
            DropIndex("dbo.PackageExcludes", new[] { "PackageId" });
            DropIndex("dbo.PackageDetails", new[] { "PackageId" });
            DropTable("dbo.PackageExcludes");
            DropTable("dbo.Packages");
            DropTable("dbo.PackageDetails");
        }
    }
}
