using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Foundation.Authorization
{
    public interface IAuthorizationService
    {
        void ApproveUser(User user);

        void DisapproveUser(User user);

        void MakeUserAdmin(User user);

        void RemoveUserAdmin(User user);
    }
}