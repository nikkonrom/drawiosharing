using System.Data.Entity;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class DrawIoSharingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public DrawIoSharingDbContext()
            : base("DefaultConnection")
        {

        }
    }
}