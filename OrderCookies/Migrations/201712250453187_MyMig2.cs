namespace OrderCookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecialDesigns", "DesignPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecialDesigns", "DesignPrice");
        }
    }
}
