using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.DomainModel
{
    public class Role : IRole
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
