namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "PreferencesID", "dbo.Preferences");
            DropForeignKey("dbo.Users", "User_UserID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "PreferencesID" });
            DropIndex("dbo.Users", new[] { "User_UserID" });
            RenameColumn(table: "dbo.Users", name: "PreferencesID", newName: "Preferences_PreferencesID");
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        FavoritesID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FavoritesID);
            
            AddColumn("dbo.Users", "Favorites_FavoritesID", c => c.Int());
            AlterColumn("dbo.Users", "Preferences_PreferencesID", c => c.Int());
            CreateIndex("dbo.Users", "Preferences_PreferencesID");
            CreateIndex("dbo.Users", "Favorites_FavoritesID");
            AddForeignKey("dbo.Users", "Preferences_PreferencesID", "dbo.Preferences", "PreferencesID");
            AddForeignKey("dbo.Users", "Favorites_FavoritesID", "dbo.Favorites", "FavoritesID");
            DropColumn("dbo.Users", "User_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "User_UserID", c => c.Int());
            DropForeignKey("dbo.Users", "Favorites_FavoritesID", "dbo.Favorites");
            DropForeignKey("dbo.Users", "Preferences_PreferencesID", "dbo.Preferences");
            DropIndex("dbo.Users", new[] { "Favorites_FavoritesID" });
            DropIndex("dbo.Users", new[] { "Preferences_PreferencesID" });
            AlterColumn("dbo.Users", "Preferences_PreferencesID", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Favorites_FavoritesID");
            DropTable("dbo.Favorites");
            RenameColumn(table: "dbo.Users", name: "Preferences_PreferencesID", newName: "PreferencesID");
            CreateIndex("dbo.Users", "User_UserID");
            CreateIndex("dbo.Users", "PreferencesID");
            AddForeignKey("dbo.Users", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Users", "PreferencesID", "dbo.Preferences", "PreferencesID", cascadeDelete: true);
        }
    }
}
