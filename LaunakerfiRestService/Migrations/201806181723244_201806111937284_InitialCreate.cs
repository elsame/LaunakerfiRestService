namespace LaunakerfiRestService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201806111937284_InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        personalId = c.String(),
                        name = c.String(),
                        address1 = c.String(),
                        address2 = c.String(),
                        postalCode = c.String(),
                        city = c.String(),
                        status = c.Int(nullable: false),
                        jobName = c.String(),
                        IdJobCatagory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.companyModels", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.companyModels", "status");
            DropTable("dbo.employeeModels");
        }
    }
}
