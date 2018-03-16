﻿using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.DomainModel
{
    public class User : IUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool UserApproved { get; set; }
    }
}
