using System.Data.Entity.Migrations;

namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ITechArt.DrawIoSharing.Repositories.DrawIoSharingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ITechArt.DrawIoSharing.Repositories.DrawIoSharingDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
