namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class missionAddTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Missions", "Start", c => c.String(nullable: false));
            AddColumn("dbo.Missions", "End", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Missions", "End");
            DropColumn("dbo.Missions", "Start");
        }
    }
}
