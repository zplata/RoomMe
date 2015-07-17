namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "HousingID", "dbo.Housings");
            DropForeignKey("dbo.Users", "CareerID", "dbo.Careers");
            DropIndex("dbo.Users", new[] { "HousingID" });
            DropIndex("dbo.Users", new[] { "CareerID" });
            RenameColumn(table: "dbo.Users", name: "HousingID", newName: "Housing_HousingID");
            RenameColumn(table: "dbo.Users", name: "CareerID", newName: "Job_CareerID");
            AddColumn("dbo.Housings", "Preferences_PreferencesID", c => c.Int());
            AlterColumn("dbo.Users", "Job_CareerID", c => c.Int());
            AlterColumn("dbo.Users", "Housing_HousingID", c => c.Int());
            CreateIndex("dbo.Housings", "Preferences_PreferencesID");
            CreateIndex("dbo.Users", "Housing_HousingID");
            CreateIndex("dbo.Users", "Job_CareerID");
            AddForeignKey("dbo.Housings", "Preferences_PreferencesID", "dbo.Preferences", "PreferencesID");
            AddForeignKey("dbo.Users", "Housing_HousingID", "dbo.Housings", "HousingID");
            AddForeignKey("dbo.Users", "Job_CareerID", "dbo.Careers", "CareerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Job_CareerID", "dbo.Careers");
            DropForeignKey("dbo.Users", "Housing_HousingID", "dbo.Housings");
            DropForeignKey("dbo.Housings", "Preferences_PreferencesID", "dbo.Preferences");
            DropIndex("dbo.Users", new[] { "Job_CareerID" });
            DropIndex("dbo.Users", new[] { "Housing_HousingID" });
            DropIndex("dbo.Housings", new[] { "Preferences_PreferencesID" });
            AlterColumn("dbo.Users", "Housing_HousingID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Job_CareerID", c => c.Int(nullable: false));
            DropColumn("dbo.Housings", "Preferences_PreferencesID");
            RenameColumn(table: "dbo.Users", name: "Job_CareerID", newName: "CareerID");
            RenameColumn(table: "dbo.Users", name: "Housing_HousingID", newName: "HousingID");
            CreateIndex("dbo.Users", "CareerID");
            CreateIndex("dbo.Users", "HousingID");
            AddForeignKey("dbo.Users", "CareerID", "dbo.Careers", "CareerID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "HousingID", "dbo.Housings", "HousingID", cascadeDelete: true);
        }
    }
}
