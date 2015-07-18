namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Favorites_FavoritesID", "dbo.Favorites");
            DropIndex("dbo.Users", new[] { "Favorites_FavoritesID" });
            DropColumn("dbo.Users", "Favorites_FavoritesID");
            DropTable("dbo.Favorites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        FavoritesID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FavoritesID);
            
            AddColumn("dbo.Users", "Favorites_FavoritesID", c => c.Int());
            CreateIndex("dbo.Users", "Favorites_FavoritesID");
            AddForeignKey("dbo.Users", "Favorites_FavoritesID", "dbo.Favorites", "FavoritesID");
        }
    }
}
