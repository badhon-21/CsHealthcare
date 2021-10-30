namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlTransactions",
                c => new
                    {
                        GT_ID = c.Int(nullable: false, identity: true),
                        GT_GL_ID = c.String(maxLength: 20),
                        GT_TR_CODE = c.String(maxLength: 10),
                        GT_TXN_NO = c.String(maxLength: 50),
                        GT_AMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GT_TRANS_DATE = c.DateTime(),
                        GT_NARATION = c.String(maxLength: 250),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.GT_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GlTransactions");
        }
    }
}
