namespace OrderCookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fillings", "FillingPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Glazes", "GlazePrice", c => c.Int(nullable: false));
            AddColumn("dbo.Pastries", "PastryPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pastries", "PastryPrice");
            DropColumn("dbo.Glazes", "GlazePrice");
            DropColumn("dbo.Fillings", "FillingPrice");
        }
    }
}
