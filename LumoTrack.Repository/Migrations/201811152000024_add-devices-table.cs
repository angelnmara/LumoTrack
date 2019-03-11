namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddevicestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        DeviceId = c.String(nullable: false, maxLength: 128),
                        FireBaseToken = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        LastNotification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Devices");
        }
    }
}
