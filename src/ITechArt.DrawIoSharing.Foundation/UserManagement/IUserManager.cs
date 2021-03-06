﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(User user, string password);

        Task<User> FindAsync(string userName, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);

        IQueryable<User> Users { get; }

        Task<User> FindByIdAsync(int userId);

        Task<IList<string>> GetRolesAsync(int userId);

        Task<IdentityResult> AddToRoleAsync(int userId, string roleName);

        Task<IdentityResult> RemoveFromRoleAsync(int userId, string roleName);
    }
}