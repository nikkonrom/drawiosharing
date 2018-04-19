using System.Collections.Generic;
using ITechArt.Common;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.DomainModel
{
    public class Role : IRole<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [UsedImplicitly]
        public Role()
        {

        }

        public Role(string name)
        {
            Name = name;
        }
    }
}