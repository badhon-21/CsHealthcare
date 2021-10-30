namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upWard : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wards", "WardTypeId", "dbo.WardTypes");
            DropIndex("dbo.Wards", new[] { "WardTypeId" });
            DropColumn("dbo.Wards", "WardTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wards", "WardTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Wards", "WardTypeId");
            AddForeignKey("dbo.Wards", "WardTypeId", "dbo.WardTypes", "Id", cascadeDelete: true);
        }
    }
}
