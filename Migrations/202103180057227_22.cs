namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Sex", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Sex", c => c.Boolean(nullable: false));
        }
    }
}
