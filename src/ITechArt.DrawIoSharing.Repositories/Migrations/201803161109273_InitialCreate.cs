using System.Data.Entity.Migrations;
using ITechArt.Common;

namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    [UsedImplicitly]
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.Roles", c => new
            {
                Id = c.String(nullable: false, maxLength: 128),
                Name = c.String(),
            }).PrimaryKey(t => t.Id);

            CreateTable("dbo.Users", c => new
            {
                Id = c.String(nullable: false, maxLength: 128),
                UserName = c.String(),
                Email = c.String(),
                Password = c.String(),
                UserApproved = c.Boolean(nullable: false),
            }).PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
