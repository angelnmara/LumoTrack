namespace LumoTrack.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnamelastname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MotherLastName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "MotherLastName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "SecondName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
