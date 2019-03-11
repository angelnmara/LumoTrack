namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class devicetype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "deviceType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "deviceType");
        }
    }
}
