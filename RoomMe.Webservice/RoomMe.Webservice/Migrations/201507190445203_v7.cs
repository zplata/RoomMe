namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "HousingPrice", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "HousingPrice", c => c.Double(nullable: false));
        }
    }
}
