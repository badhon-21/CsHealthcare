namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.PackageForCheckupDetails",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PackageForCheckUpId = c.Int(nullable: false),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.PackageForCheckUps", t => t.PackageForCheckUpId, cascadeDelete: true)
            //    .Index(t => t.PackageForCheckUpId);
            
            //CreateTable(
            //    "dbo.PackageForCheckUps",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(maxLength: 100),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.PackageForCheckupDetails", "PackageForCheckUpId", "dbo.PackageForCheckUps");
            //DropIndex("dbo.PackageForCheckupDetails", new[] { "PackageForCheckUpId" });
            //DropTable("dbo.PackageForCheckUps");
            //DropTable("dbo.PackageForCheckupDetails");
        }
    }
}
