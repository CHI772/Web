namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CID = c.String(nullable: false, maxLength: 128),
                        TID = c.String(nullable: false, maxLength: 128),
                        CName = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.CID, t.TID })
                .ForeignKey("dbo.Teachers", t => t.TID, cascadeDelete: true)
                .Index(t => t.TID);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        MID = c.String(nullable: false, maxLength: 128),
                        CID = c.String(nullable: false, maxLength: 128),
                        MName = c.String(nullable: false),
                        MDetail = c.String(nullable: false),
                        Course_CID = c.String(maxLength: 128),
                        Course_TID = c.String(maxLength: 128),
                        KnowledgePoints_KID = c.Int(),
                        KnowledgePoints_MID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MID, t.CID })
                .ForeignKey("dbo.Courses", t => new { t.Course_CID, t.Course_TID })
                .ForeignKey("dbo.KnowledgePoints", t => new { t.KnowledgePoints_KID, t.KnowledgePoints_MID })
                .Index(t => new { t.Course_CID, t.Course_TID })
                .Index(t => new { t.KnowledgePoints_KID, t.KnowledgePoints_MID });
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GName = c.String(nullable: false, maxLength: 128),
                        MID = c.String(nullable: false, maxLength: 128),
                        GID = c.Int(nullable: false),
                        Position = c.String(nullable: false),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GName, t.MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.Mission_MID, t.Mission_CID });
            
            CreateTable(
                "dbo.LearningBehaviors",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        MID = c.String(nullable: false, maxLength: 128),
                        SID = c.String(nullable: false, maxLength: 128),
                        GID = c.String(nullable: false, maxLength: 128),
                        ActionType = c.String(nullable: false),
                        subAction = c.String(nullable: false),
                        Detail = c.String(nullable: false),
                        Time = c.String(),
                        Group_GName = c.String(maxLength: 128),
                        Group_MID = c.String(maxLength: 128),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                        Student_SID = c.String(maxLength: 128),
                        Student_CID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ID, t.MID, t.SID, t.GID })
                .ForeignKey("dbo.Groups", t => new { t.Group_GName, t.Group_MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .ForeignKey("dbo.Students", t => new { t.Student_SID, t.Student_CID })
                .Index(t => new { t.Group_GName, t.Group_MID })
                .Index(t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.Student_SID, t.Student_CID });
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        SID = c.String(nullable: false, maxLength: 128),
                        CID = c.String(nullable: false, maxLength: 128),
                        SName = c.String(nullable: false),
                        SPassword = c.String(nullable: false, maxLength: 18),
                        Sex = c.Boolean(nullable: false),
                        Stage = c.String(nullable: false),
                        Grade = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.SID, t.CID });
            
            CreateTable(
                "dbo.PeerAssessments",
                c => new
                    {
                        PEID = c.Int(nullable: false),
                        MID = c.String(nullable: false, maxLength: 128),
                        SID = c.String(nullable: false, maxLength: 128),
                        GID = c.String(nullable: false, maxLength: 128),
                        PeerA = c.String(nullable: false),
                        AssessedSID = c.String(nullable: false),
                        Group_GName = c.String(maxLength: 128),
                        Group_MID = c.String(maxLength: 128),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                        Student_SID = c.String(maxLength: 128),
                        Student_CID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PEID, t.MID, t.SID, t.GID })
                .ForeignKey("dbo.Groups", t => new { t.Group_GName, t.Group_MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .ForeignKey("dbo.Students", t => new { t.Student_SID, t.Student_CID })
                .Index(t => new { t.Group_GName, t.Group_MID })
                .Index(t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.Student_SID, t.Student_CID });
            
            CreateTable(
                "dbo.Prompts",
                c => new
                    {
                        PID = c.Int(nullable: false),
                        MID = c.String(nullable: false, maxLength: 128),
                        PContent = c.String(nullable: false),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                        Student_SID = c.String(maxLength: 128),
                        Student_CID = c.String(maxLength: 128),
                        Group_GName = c.String(maxLength: 128),
                        Group_MID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PID, t.MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .ForeignKey("dbo.Students", t => new { t.Student_SID, t.Student_CID })
                .ForeignKey("dbo.Groups", t => new { t.Group_GName, t.Group_MID })
                .Index(t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.Student_SID, t.Student_CID })
                .Index(t => new { t.Group_GName, t.Group_MID });
            
            CreateTable(
                "dbo.SelfAssessments",
                c => new
                    {
                        SEID = c.Int(nullable: false),
                        MID = c.String(nullable: false, maxLength: 128),
                        SID = c.String(nullable: false, maxLength: 128),
                        GID = c.String(nullable: false, maxLength: 128),
                        CooperationLevel = c.Int(nullable: false),
                        PersonalContributionLevel = c.Int(nullable: false),
                        SelfA = c.Int(nullable: false),
                        Group_GName = c.String(maxLength: 128),
                        Group_MID = c.String(maxLength: 128),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                        Student_SID = c.String(maxLength: 128),
                        Student_CID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SEID, t.MID, t.SID, t.GID })
                .ForeignKey("dbo.Groups", t => new { t.Group_GName, t.Group_MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .ForeignKey("dbo.Students", t => new { t.Student_SID, t.Student_CID })
                .Index(t => new { t.Group_GName, t.Group_MID })
                .Index(t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.Student_SID, t.Student_CID });
            
            CreateTable(
                "dbo.TeacherAssessments",
                c => new
                    {
                        TEID = c.Int(nullable: false),
                        MID = c.String(nullable: false, maxLength: 128),
                        GID = c.String(nullable: false, maxLength: 128),
                        TeacherA = c.String(nullable: false),
                        GroupAchievementLevel = c.Int(nullable: false),
                        Group_GName = c.String(maxLength: 128),
                        Group_MID = c.String(maxLength: 128),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TEID, t.MID, t.GID })
                .ForeignKey("dbo.Groups", t => new { t.Group_GName, t.Group_MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.Group_GName, t.Group_MID })
                .Index(t => new { t.Mission_MID, t.Mission_CID });
            
            CreateTable(
                "dbo.KnowledgePoints",
                c => new
                    {
                        KID = c.Int(nullable: false),
                        MID = c.String(nullable: false, maxLength: 128),
                        KContent = c.String(nullable: false),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                        Mission_MID1 = c.String(maxLength: 128),
                        Mission_CID1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.KID, t.MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID1, t.Mission_CID1 })
                .Index(t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.Mission_MID1, t.Mission_CID1 });
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TID = c.String(nullable: false, maxLength: 128),
                        TName = c.String(nullable: false),
                        TPassword = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TID);
            
            CreateTable(
                "dbo.MissionKnowledgePoints",
                c => new
                    {
                        KID = c.String(nullable: false, maxLength: 128),
                        MID = c.String(nullable: false, maxLength: 128),
                        KnowledgePoints_KID = c.Int(),
                        KnowledgePoints_MID = c.String(maxLength: 128),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.KID, t.MID })
                .ForeignKey("dbo.KnowledgePoints", t => new { t.KnowledgePoints_KID, t.KnowledgePoints_MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.KnowledgePoints_KID, t.KnowledgePoints_MID })
                .Index(t => new { t.Mission_MID, t.Mission_CID });
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        SID = c.String(nullable: false, maxLength: 128),
                        MID = c.String(nullable: false, maxLength: 128),
                        Mission_MID = c.String(maxLength: 128),
                        Mission_CID = c.String(maxLength: 128),
                        Student_SID = c.String(maxLength: 128),
                        Student_CID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SID, t.MID })
                .ForeignKey("dbo.Missions", t => new { t.Mission_MID, t.Mission_CID })
                .ForeignKey("dbo.Students", t => new { t.Student_SID, t.Student_CID })
                .Index(t => new { t.Mission_MID, t.Mission_CID })
                .Index(t => new { t.Student_SID, t.Student_CID });
            
            CreateTable(
                "dbo.StudentGroup1",
                c => new
                    {
                        Student_SID = c.String(nullable: false, maxLength: 128),
                        Student_CID = c.String(nullable: false, maxLength: 128),
                        Group_GName = c.String(nullable: false, maxLength: 128),
                        Group_MID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Student_SID, t.Student_CID, t.Group_GName, t.Group_MID })
                .ForeignKey("dbo.Students", t => new { t.Student_SID, t.Student_CID }, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => new { t.Group_GName, t.Group_MID }, cascadeDelete: true)
                .Index(t => new { t.Student_SID, t.Student_CID })
                .Index(t => new { t.Group_GName, t.Group_MID });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGroups", new[] { "Student_SID", "Student_CID" }, "dbo.Students");
            DropForeignKey("dbo.StudentGroups", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.MissionKnowledgePoints", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.MissionKnowledgePoints", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints");
            DropForeignKey("dbo.Courses", "TID", "dbo.Teachers");
            DropForeignKey("dbo.KnowledgePoints", new[] { "Mission_MID1", "Mission_CID1" }, "dbo.Missions");
            DropForeignKey("dbo.Missions", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" }, "dbo.KnowledgePoints");
            DropForeignKey("dbo.KnowledgePoints", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.TeacherAssessments", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.TeacherAssessments", new[] { "Group_GName", "Group_MID" }, "dbo.Groups");
            DropForeignKey("dbo.Prompts", new[] { "Group_GName", "Group_MID" }, "dbo.Groups");
            DropForeignKey("dbo.Groups", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.SelfAssessments", new[] { "Student_SID", "Student_CID" }, "dbo.Students");
            DropForeignKey("dbo.SelfAssessments", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.SelfAssessments", new[] { "Group_GName", "Group_MID" }, "dbo.Groups");
            DropForeignKey("dbo.Prompts", new[] { "Student_SID", "Student_CID" }, "dbo.Students");
            DropForeignKey("dbo.Prompts", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.PeerAssessments", new[] { "Student_SID", "Student_CID" }, "dbo.Students");
            DropForeignKey("dbo.PeerAssessments", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.PeerAssessments", new[] { "Group_GName", "Group_MID" }, "dbo.Groups");
            DropForeignKey("dbo.LearningBehaviors", new[] { "Student_SID", "Student_CID" }, "dbo.Students");
            DropForeignKey("dbo.StudentGroup1", new[] { "Group_GName", "Group_MID" }, "dbo.Groups");
            DropForeignKey("dbo.StudentGroup1", new[] { "Student_SID", "Student_CID" }, "dbo.Students");
            DropForeignKey("dbo.LearningBehaviors", new[] { "Mission_MID", "Mission_CID" }, "dbo.Missions");
            DropForeignKey("dbo.LearningBehaviors", new[] { "Group_GName", "Group_MID" }, "dbo.Groups");
            DropForeignKey("dbo.Missions", new[] { "Course_CID", "Course_TID" }, "dbo.Courses");
            DropIndex("dbo.StudentGroup1", new[] { "Group_GName", "Group_MID" });
            DropIndex("dbo.StudentGroup1", new[] { "Student_SID", "Student_CID" });
            DropIndex("dbo.StudentGroups", new[] { "Student_SID", "Student_CID" });
            DropIndex("dbo.StudentGroups", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.MissionKnowledgePoints", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.MissionKnowledgePoints", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" });
            DropIndex("dbo.KnowledgePoints", new[] { "Mission_MID1", "Mission_CID1" });
            DropIndex("dbo.KnowledgePoints", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.TeacherAssessments", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.TeacherAssessments", new[] { "Group_GName", "Group_MID" });
            DropIndex("dbo.SelfAssessments", new[] { "Student_SID", "Student_CID" });
            DropIndex("dbo.SelfAssessments", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.SelfAssessments", new[] { "Group_GName", "Group_MID" });
            DropIndex("dbo.Prompts", new[] { "Group_GName", "Group_MID" });
            DropIndex("dbo.Prompts", new[] { "Student_SID", "Student_CID" });
            DropIndex("dbo.Prompts", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.PeerAssessments", new[] { "Student_SID", "Student_CID" });
            DropIndex("dbo.PeerAssessments", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.PeerAssessments", new[] { "Group_GName", "Group_MID" });
            DropIndex("dbo.LearningBehaviors", new[] { "Student_SID", "Student_CID" });
            DropIndex("dbo.LearningBehaviors", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.LearningBehaviors", new[] { "Group_GName", "Group_MID" });
            DropIndex("dbo.Groups", new[] { "Mission_MID", "Mission_CID" });
            DropIndex("dbo.Missions", new[] { "KnowledgePoints_KID", "KnowledgePoints_MID" });
            DropIndex("dbo.Missions", new[] { "Course_CID", "Course_TID" });
            DropIndex("dbo.Courses", new[] { "TID" });
            DropTable("dbo.StudentGroup1");
            DropTable("dbo.StudentGroups");
            DropTable("dbo.MissionKnowledgePoints");
            DropTable("dbo.Teachers");
            DropTable("dbo.KnowledgePoints");
            DropTable("dbo.TeacherAssessments");
            DropTable("dbo.SelfAssessments");
            DropTable("dbo.Prompts");
            DropTable("dbo.PeerAssessments");
            DropTable("dbo.Students");
            DropTable("dbo.LearningBehaviors");
            DropTable("dbo.Groups");
            DropTable("dbo.Missions");
            DropTable("dbo.Courses");
        }
    }
}
