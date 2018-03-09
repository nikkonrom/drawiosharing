namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
