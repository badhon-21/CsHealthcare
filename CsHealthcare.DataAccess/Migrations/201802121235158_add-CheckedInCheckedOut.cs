namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCheckedInCheckedOut : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckInCheckOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        CheckInDateTime = c.DateTime(),
                        CheckOutDateTime = c.DateTime(),
                        TotalHours = c.Decimal(precision: 18, scale: 2),
                        Remarks = c.String(),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeInfoes", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckInCheckOuts", "EmployeeId", "dbo.EmployeeInfoes");
            DropIndex("dbo.CheckInCheckOuts", new[] { "EmployeeId" });
            DropTable("dbo.CheckInCheckOuts");
        }
    }
}
