namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key_guid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Devices");
            AlterColumn("dbo.Devices", "DeviceId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Devices", "DeviceId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Devices");
            AlterColumn("dbo.Devices", "DeviceId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Devices", "DeviceId");
        }
    }
}
