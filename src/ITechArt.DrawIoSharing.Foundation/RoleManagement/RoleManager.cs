using ITechArt.DrawIoSharing.DomainModel;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.RoleManagement
{
    public class RoleManager : RoleManager<Role, int>, IRoleManager
    {
        public RoleManager(IRoleStore<Role, int> store)
            : base(store)
        {

        }
    }
}