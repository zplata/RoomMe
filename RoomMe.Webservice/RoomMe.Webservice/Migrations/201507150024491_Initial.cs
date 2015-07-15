namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        CareerID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Company = c.String(),
                    })
                .PrimaryKey(t => t.CareerID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CareerID = c.Int(nullable: false),
                        HousingLocationID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        PreferencesID = c.Int(nullable: false),
                        User_UserID = c.Int(),
                        HousingLocation_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.Locations", t => t.HousingLocation_LocationID)
                .ForeignKey("dbo.Careers", t => t.CareerID, cascadeDelete: true)
                .ForeignKey("dbo.Preferences", t => t.PreferencesID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.HousingLocation_LocationID)
                .Index(t => t.CareerID)
                .Index(t => t.PreferencesID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        PreferencesID = c.Int(nullable: false, identity: true),
                        Gender = c.Int(),
                        Age = c.Int(),
                        UpperPriceLimit = c.Double(),
                        LowerPriceLimit = c.Double(),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.PreferencesID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Preferences_PreferencesID = c.Int(),
                    })
                .PrimaryKey(t => t.TagID)
                .ForeignKey("dbo.Preferences", t => t.Preferences_PreferencesID)
                .Index(t => t.Preferences_PreferencesID);
            
            CreateTable(
                "dbo.TagUsers",
                c => new
                    {
                        Tag_TagID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagID, t.User_UserID })
                .ForeignKey("dbo.Tags", t => t.Tag_TagID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Tag_TagID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PreferencesID", "dbo.Preferences");
            DropForeignKey("dbo.Tags", "Preferences_PreferencesID", "dbo.Preferences");
            DropForeignKey("dbo.TagUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.TagUsers", "Tag_TagID", "dbo.Tags");
            DropForeignKey("dbo.Preferences", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Users", "CareerID", "dbo.Careers");
            DropForeignKey("dbo.Users", "HousingLocation_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Users", "User_UserID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "PreferencesID" });
            DropIndex("dbo.Tags", new[] { "Preferences_PreferencesID" });
            DropIndex("dbo.TagUsers", new[] { "User_UserID" });
            DropIndex("dbo.TagUsers", new[] { "Tag_TagID" });
            DropIndex("dbo.Preferences", new[] { "Location_LocationID" });
            DropIndex("dbo.Users", new[] { "CareerID" });
            DropIndex("dbo.Users", new[] { "HousingLocation_LocationID" });
            DropIndex("dbo.Users", new[] { "User_UserID" });
            DropTable("dbo.TagUsers");
            DropTable("dbo.Tags");
            DropTable("dbo.Preferences");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.Careers");
        }
    }
}
