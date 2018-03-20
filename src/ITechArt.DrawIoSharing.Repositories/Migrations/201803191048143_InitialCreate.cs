using System.Data.Entity.Migrations;
using ITechArt.Common;

namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    [UsedImplicitly]
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.Users", c => new
            {
                Id = c.Int(nullable: false, identity: true),
                UserName = c.String(),
                Email = c.String(),
                Password = c.String(),
            }).PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
