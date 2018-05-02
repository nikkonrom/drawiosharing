using System.Data.Entity.Migrations;
using ITechArt.Common;

namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    [UsedImplicitly]
    public partial class Authorization : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.Roles", c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Name = c.String(),
            }).PrimaryKey(t => t.Id);

            CreateTable("dbo.UserRoles", c => new
            {
                Id = c.Int(nullable: false, identity: true),
                UserId = c.Int(nullable: false),
                RoleId = c.Int(nullable: false),
            }).PrimaryKey(t => t.Id).ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true).Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
