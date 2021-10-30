namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totalamountonot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationTheatres", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OperationTheatres", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OperationTheatres", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OperationTheatres", "CreatedBy");
            DropColumn("dbo.OperationTheatres", "CreatedDate");
            DropColumn("dbo.OperationTheatres", "TotalAmount");
        }
    }
}
