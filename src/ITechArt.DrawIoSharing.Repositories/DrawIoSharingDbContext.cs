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
        public DbSet<Role> Roles { get; set; }

        static DrawIoSharingDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DrawIoSharingDbContext, Configuration>());
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public DrawIoSharingDbContext()
            : base(ConnectionName)
        {

        }

        public static DrawIoSharingDbContext Create()
        {
            return new DrawIoSharingDbContext();
        }
    }
}