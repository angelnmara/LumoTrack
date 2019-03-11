namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedeviceid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Devices");
            AddColumn("dbo.Devices", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Devices", "Id");
            DropColumn("dbo.Devices", "DeviceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "DeviceId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.Devices");
            DropColumn("dbo.Devices", "Id");
            AddPrimaryKey("dbo.Devices", "DeviceId");
        }
    }
}
