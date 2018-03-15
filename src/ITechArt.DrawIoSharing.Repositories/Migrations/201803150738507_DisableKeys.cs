namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisableKeys : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AddPrimaryKey("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", new[] { "Id", "UserName" });
        }
    }
}
