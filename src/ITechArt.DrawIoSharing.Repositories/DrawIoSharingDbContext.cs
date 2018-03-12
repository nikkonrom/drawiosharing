using System.Data.Entity;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Repositories
{
    [UsedImplicitly]
    public class DrawIoSharingDbContext : DbContext
    {
        private const string ConnectionName = "DefaultConnection";


        public DbSet<User> Users { get; set; }


        public DrawIoSharingDbContext()
            : base(ConnectionName)
        {

        }
    }
}