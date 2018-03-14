using System.ComponentModel.DataAnnotations;
using ITechArt.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITechArt.DrawIoSharing.DomainModel
{
    public class User : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool UserApproved { get; set; }
    }
}
