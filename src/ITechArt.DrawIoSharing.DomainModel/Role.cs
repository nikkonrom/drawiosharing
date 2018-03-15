using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.DomainModel
{
    public class Role : IRole
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
