using System.Data.Entity;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class DrawIoSharingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private const string ConnectionName = "DefaultConnection";


        public DrawIoSharingDbContext()
            : base(ConnectionName)
        {

        }
    }
}