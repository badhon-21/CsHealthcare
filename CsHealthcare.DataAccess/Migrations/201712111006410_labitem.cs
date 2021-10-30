namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class labitem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LabItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        PackageSize = c.String(maxLength: 100),
                        RewardedLevel = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LabItems");
        }
    }
}
