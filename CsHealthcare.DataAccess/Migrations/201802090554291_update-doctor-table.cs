namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedoctortable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorInformations", "ShiftId", c => c.Int(nullable: true));
            AddColumn("dbo.DoctorInformations", "Badgenumber", c => c.String(maxLength: 50));
            CreateIndex("dbo.DoctorInformations", "ShiftId");
            AddForeignKey("dbo.DoctorInformations", "ShiftId", "dbo.Shifts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorInformations", "ShiftId", "dbo.Shifts");
            DropIndex("dbo.DoctorInformations", new[] { "ShiftId" });
            DropColumn("dbo.DoctorInformations", "Badgenumber");
            DropColumn("dbo.DoctorInformations", "ShiftId");
        }
    }
}
