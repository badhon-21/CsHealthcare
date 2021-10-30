namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anesthesia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anesthesias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnesdthesiaName = c.String(),
                        AnesthesiaPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperationTheatreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationTheatres", t => t.OperationTheatreId)
                .Index(t => t.OperationTheatreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anesthesias", "OperationTheatreId", "dbo.OperationTheatres");
            DropIndex("dbo.Anesthesias", new[] { "OperationTheatreId" });
            DropTable("dbo.Anesthesias");
        }
    }
}
