namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_score : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Score", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Score");
        }
    }
}
