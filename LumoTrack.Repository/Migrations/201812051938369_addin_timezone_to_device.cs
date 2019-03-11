namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addin_timezone_to_device : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "TimeZone", c => c.String());
            DropColumn("dbo.Inboxes", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inboxes", "Title", c => c.String());
            DropColumn("dbo.Devices", "TimeZone");
        }
    }
}
