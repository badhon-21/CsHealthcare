namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ccc : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Beds",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            WardId = c.Int(nullable: false),
            //            Name = c.String(maxLength: 100),
            //            BedType = c.String(maxLength: 100),
            //            Description = c.String(maxLength: 100),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Wards", t => t.WardId, cascadeDelete: true)
            //    .Index(t => t.WardId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Beds", "WardId", "dbo.Wards");
            //DropIndex("dbo.Beds", new[] { "WardId" });
            //DropTable("dbo.Beds");
        }
    }
}
