namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conflictmigration1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Physiotherapies",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Category = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.Physiotherapies");
        }
    }
}
