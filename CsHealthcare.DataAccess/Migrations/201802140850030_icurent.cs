namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class icurent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ICURents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ICUId = c.Int(nullable: false),
                        ICUBedsId = c.Int(nullable: false),
                        RentDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PatientCode = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ICUs", t => t.ICUId, cascadeDelete: true)
                .ForeignKey("dbo.ICUBeds", t => t.ICUBedsId, cascadeDelete: true)
                .Index(t => t.ICUId)
                .Index(t => t.ICUBedsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ICURents", "ICUBedsId", "dbo.ICUBeds");
            DropForeignKey("dbo.ICURents", "ICUId", "dbo.ICUs");
            DropIndex("dbo.ICURents", new[] { "ICUBedsId" });
            DropIndex("dbo.ICURents", new[] { "ICUId" });
            DropTable("dbo.ICURents");
        }
    }
}
