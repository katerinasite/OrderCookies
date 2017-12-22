namespace OrderCookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialDesigns",
                c => new
                    {
                        SpecialDesignId = c.Int(nullable: false, identity: true),
                        Design = c.String(),
                    })
                .PrimaryKey(t => t.SpecialDesignId);
            
            AddColumn("dbo.CookieForms", "CookieDescription", c => c.String());
            AddColumn("dbo.Cookies", "SpecialDesignId", c => c.Int());
            AddColumn("dbo.Cookies", "Comments", c => c.String());
            CreateIndex("dbo.Cookies", "SpecialDesignId");
            AddForeignKey("dbo.Cookies", "SpecialDesignId", "dbo.SpecialDesigns", "SpecialDesignId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cookies", "SpecialDesignId", "dbo.SpecialDesigns");
            DropIndex("dbo.Cookies", new[] { "SpecialDesignId" });
            DropColumn("dbo.Cookies", "Comments");
            DropColumn("dbo.Cookies", "SpecialDesignId");
            DropColumn("dbo.CookieForms", "CookieDescription");
            DropTable("dbo.SpecialDesigns");
        }
    }
}
