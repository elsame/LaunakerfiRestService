namespace LaunakerfiRestService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.companyModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        personalId = c.String(),
                        name = c.String(),
                        home = c.String(),
                        postalCode = c.String(),
                        city = c.String(),
                        phoneNumber = c.String(),
                        job = c.String(),
                        sectorCodes = c.String(),
                        bankNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.payCheckModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdLaunthegi = c.Int(nullable: false),
                        launasedillprent = c.Binary(),
                        timiFra = c.DateTime(nullable: false),
                        timiTil = c.DateTime(nullable: false),
                        IdLaunagreidsla = c.Int(nullable: false),
                        IdRskSkilagrein = c.Int(nullable: false),
                        IdLifeyrirSkilagrein = c.Int(nullable: false),
                        astand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.payCheckModels");
            DropTable("dbo.companyModels");
        }
    }
}
