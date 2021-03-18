namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idtest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Missions", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints");
            DropForeignKey("dbo.MissionKnowledgePoints", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints");
            DropPrimaryKey("dbo.KnowledgePoints");
            AlterColumn("dbo.KnowledgePoints", "KID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.KnowledgePoints", new[] { "KID", "MID" });
            AddForeignKey("dbo.Missions", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints", new[] { "KID", "MID" });
            AddForeignKey("dbo.MissionKnowledgePoints", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints", new[] { "KID", "MID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MissionKnowledgePoints", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints");
            DropForeignKey("dbo.Missions", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints");
            DropPrimaryKey("dbo.KnowledgePoints");
            AlterColumn("dbo.KnowledgePoints", "KID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.KnowledgePoints", new[] { "KID", "MID" });
            AddForeignKey("dbo.MissionKnowledgePoints", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints", new[] { "KID", "MID" });
            AddForeignKey("dbo.Missions", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints", new[] { "KID", "MID" });
        }
    }
}
