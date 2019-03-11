namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class title_notification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Title");
        }
    }
}
