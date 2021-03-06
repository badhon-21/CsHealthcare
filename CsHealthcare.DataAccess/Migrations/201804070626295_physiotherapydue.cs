namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class physiotherapydue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDTherapies", "DeuAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OPDTherapies", "DeuAmount");
        }
    }
}
