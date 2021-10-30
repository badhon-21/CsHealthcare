namespace CsHealthcare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insurance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsuranceCompanies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 20),
                        Website = c.String(maxLength: 20),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InsurancePlans",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        InsuranceCompanyId = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 50),
                        RecStatus = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InsuranceCompanies", t => t.InsuranceCompanyId)
                .Index(t => t.InsuranceCompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsurancePlans", "InsuranceCompanyId", "dbo.InsuranceCompanies");
            DropIndex("dbo.InsurancePlans", new[] { "InsuranceCompanyId" });
            DropTable("dbo.InsurancePlans");
            DropTable("dbo.InsuranceCompanies");
        }
    }
}
