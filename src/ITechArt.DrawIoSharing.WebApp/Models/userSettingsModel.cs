using System.Collections.Generic;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.RoleManagement;

namespace ITechArt.DrawIoSharing.WebApp.Models
{
    public class UserSettingsModel
    {
        public KeyValuePair<User, IList<DefaultRole>> GetModel { get; set; }

        public UserSettingsPostModel PostModel { get; set; }


        public UserSettingsModel()
        {

        }
    }
}