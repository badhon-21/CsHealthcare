namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddoctoratttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorAttendenceCheckInOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocId = c.String(maxLength: 50),
                        ChkInTime = c.DateTime(),
                        Remarks = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DoctorAttendenceCheckInOuts");
        }
    }
}
