using System.Data.Entity;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Repositories
{
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