using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.DomainModel
{
    class Role : IRole
    {
        public string Id { get; }
        public string Name { get; set; }
    }
}
