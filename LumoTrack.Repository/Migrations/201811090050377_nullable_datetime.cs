namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inboxes", "ResponseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inboxes", "ResponseDate", c => c.DateTime(nullable: false));
        }
    }
}
