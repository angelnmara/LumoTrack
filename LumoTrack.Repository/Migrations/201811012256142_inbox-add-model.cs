namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inboxaddmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inboxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        TruckName = c.String(),
                        TruckId = c.String(),
                        ReportType = c.Int(nullable: false),
                        Message = c.String(),
                        Response = c.String(),
                        ResponseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inboxes");
        }
    }
}
