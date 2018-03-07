using System.Data.Entity;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class EFServiceContext : DbContext
    {

        public DbSet<User> Users { get; set; }


        public EFServiceContext() 
            : base("DefaultConnection") { }
    }
}
