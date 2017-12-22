namespace OrderCookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CookieForms",
                c => new
                    {
                        CookieFormId = c.Int(nullable: false, identity: true),
                        CookieFormName = c.String(),
                    })
                .PrimaryKey(t => t.CookieFormId);
            
            CreateTable(
                "dbo.Cookies",
                c => new
                    {
                        CookiesId = c.Int(nullable: false, identity: true),
                        CookiesName = c.String(),
                        CookieFormId = c.Int(nullable: false),
                        CookieSizeId = c.Int(nullable: false),
                        PastryId = c.Int(nullable: false),
                        FillingId = c.Int(nullable: false),
                        GlazeId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CookiesId)
                .ForeignKey("dbo.CookieForms", t => t.CookieFormId, cascadeDelete: true)
                .ForeignKey("dbo.CookieSizes", t => t.CookieSizeId, cascadeDelete: true)
                .ForeignKey("dbo.Fillings", t => t.FillingId, cascadeDelete: true)
                .ForeignKey("dbo.Glazes", t => t.GlazeId, cascadeDelete: true)
                .ForeignKey("dbo.Pastries", t => t.PastryId, cascadeDelete: true)
                .Index(t => t.CookieFormId)
                .Index(t => t.CookieSizeId)
                .Index(t => t.PastryId)
                .Index(t => t.FillingId)
                .Index(t => t.GlazeId);
            
            CreateTable(
                "dbo.CookieSizes",
                c => new
                    {
                        CookieSizeId = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CookieSizeId);
            
            CreateTable(
                "dbo.Fillings",
                c => new
                    {
                        FillingId = c.Int(nullable: false, identity: true),
                        FillingName = c.String(),
                    })
                .PrimaryKey(t => t.FillingId);
            
            CreateTable(
                "dbo.Glazes",
                c => new
                    {
                        GlazeId = c.Int(nullable: false, identity: true),
                        GlazeName = c.String(),
                    })
                .PrimaryKey(t => t.GlazeId);
            
            CreateTable(
                "dbo.Pastries",
                c => new
                    {
                        PastryId = c.Int(nullable: false, identity: true),
                        PastryName = c.String(),
                    })
                .PrimaryKey(t => t.PastryId);
            
            CreateTable(
                "dbo.FinalOrders",
                c => new
                    {
                        FinalOrderId = c.Int(nullable: false, identity: true),
                        FinalAmount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FinalOrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.MiddleOrders",
                c => new
                    {
                        MiddleOrderId = c.Int(nullable: false, identity: true),
                        FinalOrderId = c.Int(nullable: false),
                        CookiesId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        MiddleAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MiddleOrderId)
                .ForeignKey("dbo.Cookies", t => t.CookiesId, cascadeDelete: true)
                .ForeignKey("dbo.FinalOrders", t => t.FinalOrderId, cascadeDelete: true)
                .Index(t => t.FinalOrderId)
                .Index(t => t.CookiesId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserFIO = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FinalOrders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MiddleOrders", "FinalOrderId", "dbo.FinalOrders");
            DropForeignKey("dbo.MiddleOrders", "CookiesId", "dbo.Cookies");
            DropForeignKey("dbo.Cookies", "PastryId", "dbo.Pastries");
            DropForeignKey("dbo.Cookies", "GlazeId", "dbo.Glazes");
            DropForeignKey("dbo.Cookies", "FillingId", "dbo.Fillings");
            DropForeignKey("dbo.Cookies", "CookieSizeId", "dbo.CookieSizes");
            DropForeignKey("dbo.Cookies", "CookieFormId", "dbo.CookieForms");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.MiddleOrders", new[] { "CookiesId" });
            DropIndex("dbo.MiddleOrders", new[] { "FinalOrderId" });
            DropIndex("dbo.FinalOrders", new[] { "User_Id" });
            DropIndex("dbo.Cookies", new[] { "GlazeId" });
            DropIndex("dbo.Cookies", new[] { "FillingId" });
            DropIndex("dbo.Cookies", new[] { "PastryId" });
            DropIndex("dbo.Cookies", new[] { "CookieSizeId" });
            DropIndex("dbo.Cookies", new[] { "CookieFormId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.MiddleOrders");
            DropTable("dbo.FinalOrders");
            DropTable("dbo.Pastries");
            DropTable("dbo.Glazes");
            DropTable("dbo.Fillings");
            DropTable("dbo.CookieSizes");
            DropTable("dbo.Cookies");
            DropTable("dbo.CookieForms");
        }
    }
}
