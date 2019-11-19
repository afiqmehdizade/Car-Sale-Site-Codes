namespace AspFinalProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adverts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CityId = c.Int(nullable: false),
                        IsVip = c.Boolean(nullable: false),
                        AvtomobilId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Avtomobils", t => t.AvtomobilId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.AvtomobilId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Avtomobils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        MadeYear = c.DateTime(nullable: false),
                        EngineCapacity = c.String(nullable: false, maxLength: 20),
                        KiloMetre = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 20),
                        OilId = c.Int(nullable: false),
                        TransMission = c.Boolean(nullable: false),
                        Context = c.String(nullable: false, maxLength: 500),
                        Image = c.String(),
                        Marka_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Markas", t => t.Marka_Id)
                .ForeignKey("dbo.Oils", t => t.OilId, cascadeDelete: true)
                .Index(t => t.ModelId)
                .Index(t => t.OilId)
                .Index(t => t.Marka_Id);
            
            CreateTable(
                "dbo.Markas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarkaName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(maxLength: 50),
                        MarkaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Markas", t => t.MarkaId, cascadeDelete: true)
                .Index(t => t.MarkaId);
            
            CreateTable(
                "dbo.Oils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YanacaqAdi = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(maxLength: 50),
                        Lastname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 13),
                        Password = c.String(nullable: false, maxLength: 300),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UN_Email");
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 500),
                        CreatedAt = c.DateTime(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adverts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Adverts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Adverts", "AvtomobilId", "dbo.Avtomobils");
            DropForeignKey("dbo.Avtomobils", "OilId", "dbo.Oils");
            DropForeignKey("dbo.Avtomobils", "Marka_Id", "dbo.Markas");
            DropForeignKey("dbo.Models", "MarkaId", "dbo.Markas");
            DropForeignKey("dbo.Avtomobils", "ModelId", "dbo.Models");
            DropIndex("dbo.Users", "UN_Email");
            DropIndex("dbo.Models", new[] { "MarkaId" });
            DropIndex("dbo.Avtomobils", new[] { "Marka_Id" });
            DropIndex("dbo.Avtomobils", new[] { "OilId" });
            DropIndex("dbo.Avtomobils", new[] { "ModelId" });
            DropIndex("dbo.Adverts", new[] { "UserId" });
            DropIndex("dbo.Adverts", new[] { "AvtomobilId" });
            DropIndex("dbo.Adverts", new[] { "CityId" });
            DropTable("dbo.News");
            DropTable("dbo.Users");
            DropTable("dbo.Cities");
            DropTable("dbo.Oils");
            DropTable("dbo.Models");
            DropTable("dbo.Markas");
            DropTable("dbo.Avtomobils");
            DropTable("dbo.Adverts");
        }
    }
}
