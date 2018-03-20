using System.Data.Entity.Migrations;
using ITechArt.Common;

namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    [UsedImplicitly]
    public sealed class Configuration : DbMigrationsConfiguration<DrawIoSharingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
