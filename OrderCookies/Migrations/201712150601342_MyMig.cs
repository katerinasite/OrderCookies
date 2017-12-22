namespace OrderCookies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cookies", "GlazeId", "dbo.Glazes");
            DropIndex("dbo.Cookies", new[] { "GlazeId" });
            RenameColumn(table: "dbo.FinalOrders", name: "User_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.FinalOrders", name: "IX_User_Id", newName: "IX_ApplicationUserId");
            AlterColumn("dbo.Cookies", "GlazeId", c => c.Int());
            CreateIndex("dbo.Cookies", "GlazeId");
            AddForeignKey("dbo.Cookies", "GlazeId", "dbo.Glazes", "GlazeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cookies", "GlazeId", "dbo.Glazes");
            DropIndex("dbo.Cookies", new[] { "GlazeId" });
            AlterColumn("dbo.Cookies", "GlazeId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.FinalOrders", name: "IX_ApplicationUserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.FinalOrders", name: "ApplicationUserId", newName: "User_Id");
            CreateIndex("dbo.Cookies", "GlazeId");
            AddForeignKey("dbo.Cookies", "GlazeId", "dbo.Glazes", "GlazeId", cascadeDelete: true);
        }
    }
}
