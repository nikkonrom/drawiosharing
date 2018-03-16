namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyTypeChanged : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Roles");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Roles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Roles", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            DropColumn("dbo.Users", "UserApproved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserApproved", c => c.Boolean(nullable: false));
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Roles", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Roles", "Id");
        }
    }
}
