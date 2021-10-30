namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDrug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DRUG", "D_DISCOUNT", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DRUG", "D_DISCOUNT");
        }
    }
}
