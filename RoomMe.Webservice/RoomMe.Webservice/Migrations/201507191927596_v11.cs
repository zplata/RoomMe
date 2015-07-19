namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Locations", "Latitude", c => c.Single(nullable: false));
        }
    }
}
