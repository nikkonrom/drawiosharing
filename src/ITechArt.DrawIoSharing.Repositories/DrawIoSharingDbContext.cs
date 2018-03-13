using System.Data.Entity;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Repositories.Migrations;

namespace ITechArt.DrawIoSharing.Repositories
{
    [UsedImplicitly]
    public class DrawIoSharingDbContext : DbContext
    {
        private const string ConnectionName = "DefaultConnection";


        public DbSet<User> Users { get; set; }


        static DrawIoSharingDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DrawIoSharingDbContext, Configuration>());
        }

        public DrawIoSharingDbContext()
            : base(ConnectionName)
        {

        }
    }
}