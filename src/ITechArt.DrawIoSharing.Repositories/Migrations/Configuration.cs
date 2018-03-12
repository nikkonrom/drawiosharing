using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    public sealed class Configuration :DbMigrationsConfiguration<DrawIoSharingDbContext>

    {
        protected override void Seed(DrawIoSharingDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
