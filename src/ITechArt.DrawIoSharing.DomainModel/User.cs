﻿using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.DomainModel
{
    public class User : IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        

        public User(string userName, string email) : this()
        {
            UserName = userName;
            Email = email;
        }
        public User()
        {

        }
    }
}
