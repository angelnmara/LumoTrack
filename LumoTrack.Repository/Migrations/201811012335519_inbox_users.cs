namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inbox_users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inboxes", "UserId", c => c.String());
            AddColumn("dbo.Inboxes", "UserResponseId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inboxes", "UserResponseId");
            DropColumn("dbo.Inboxes", "UserId");
        }
    }
}
