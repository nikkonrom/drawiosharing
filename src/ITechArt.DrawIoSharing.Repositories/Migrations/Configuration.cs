using System.Data.Entity.Migrations;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.RoleManagement;

namespace ITechArt.DrawIoSharing.Repositories.Migrations
{
    [UsedImplicitly]
    public sealed class Configuration : DbMigrationsConfiguration<DrawIoSharingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DrawIoSharingDbContext context)
        {
            base.Seed(context);
            context.Roles.AddOrUpdate(role => role.Name,
                new Role(DefaultRole.DefaultUser.ToString()),
                new Role(DefaultRole.ApprovedUser.ToString()),
                new Role(DefaultRole.Admin.ToString()),
                new Role(DefaultRole.BannedUser.ToString()));
        }
    }
}
