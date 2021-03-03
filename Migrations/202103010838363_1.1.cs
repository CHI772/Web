namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AID = c.String(nullable: false, maxLength: 128),
                        APassword = c.String(),
                        AName = c.String(),
                    })
                .PrimaryKey(t => t.AID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
