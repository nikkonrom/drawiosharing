using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.Foundation;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class EFServiceContext : DbContext
    {
        public EFServiceContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
    }
}
