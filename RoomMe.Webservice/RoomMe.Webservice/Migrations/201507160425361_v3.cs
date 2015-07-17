namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Housings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Housings", "Name");
        }
    }
}
