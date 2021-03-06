namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patienteducation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DegreeName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientEducations");
        }
    }
}
