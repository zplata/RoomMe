namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "HousingLocation_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Preferences", "Location_LocationID", "dbo.Locations");
            DropIndex("dbo.Users", new[] { "HousingLocation_LocationID" });
            DropIndex("dbo.Preferences", new[] { "Location_LocationID" });
            CreateTable(
                "dbo.Housings",
                c => new
                    {
                        HousingID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.HousingID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            AddColumn("dbo.Users", "HousingID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "HousingPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Locations", "Preferences_PreferencesID", c => c.Int());
            CreateIndex("dbo.Users", "HousingID");
            CreateIndex("dbo.Locations", "Preferences_PreferencesID");
            AddForeignKey("dbo.Users", "HousingID", "dbo.Housings", "HousingID", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "Preferences_PreferencesID", "dbo.Preferences", "PreferencesID");
            DropColumn("dbo.Users", "HousingLocationID");
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "HousingLocation_LocationID");
            DropColumn("dbo.Preferences", "Location_LocationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "Location_LocationID", c => c.Int());
            AddColumn("dbo.Users", "HousingLocation_LocationID", c => c.Int());
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "HousingLocationID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Locations", "Preferences_PreferencesID", "dbo.Preferences");
            DropForeignKey("dbo.Users", "HousingID", "dbo.Housings");
            DropForeignKey("dbo.Housings", "LocationID", "dbo.Locations");
            DropIndex("dbo.Locations", new[] { "Preferences_PreferencesID" });
            DropIndex("dbo.Users", new[] { "HousingID" });
            DropIndex("dbo.Housings", new[] { "LocationID" });
            DropColumn("dbo.Locations", "Preferences_PreferencesID");
            DropColumn("dbo.Users", "HousingPrice");
            DropColumn("dbo.Users", "HousingID");
            DropTable("dbo.Housings");
            CreateIndex("dbo.Preferences", "Location_LocationID");
            CreateIndex("dbo.Users", "HousingLocation_LocationID");
            AddForeignKey("dbo.Preferences", "Location_LocationID", "dbo.Locations", "LocationID");
            AddForeignKey("dbo.Users", "HousingLocation_LocationID", "dbo.Locations", "LocationID");
        }
    }
}
