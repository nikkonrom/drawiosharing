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
            context.Roles.AddOrUpdate(role => role.Id,
                new Role(SupportedRoles.ApprovedUser.ToString()),
                new Role(SupportedRoles.Admin.ToString()));
        }
    }
}
