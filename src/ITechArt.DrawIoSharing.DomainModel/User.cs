using System.Collections.Generic;
using ITechArt.Common;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.DomainModel
{
    public class User : IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<UserRole> Roles { get; set; }


        [UsedImplicitly]
        public User()
        {

        }

        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}
