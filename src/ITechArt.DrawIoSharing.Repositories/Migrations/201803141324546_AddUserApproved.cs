namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserApproved : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserApproved");
        }
    }
}
