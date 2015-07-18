namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7_Auth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AuthToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AuthToken");
        }
    }
}
