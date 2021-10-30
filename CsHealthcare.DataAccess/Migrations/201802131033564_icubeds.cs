namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class icubeds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ICUBeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PriceByDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceByHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IcuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ICUs", t => t.IcuId)
                .Index(t => t.IcuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ICUBeds", "IcuId", "dbo.ICUs");
            DropIndex("dbo.ICUBeds", new[] { "IcuId" });
            DropTable("dbo.ICUBeds");
        }
    }
}
