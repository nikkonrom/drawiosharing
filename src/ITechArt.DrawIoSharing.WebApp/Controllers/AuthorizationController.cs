using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.Authorization;
using ITechArt.DrawIoSharing.Foundation.RoleManagement;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using ITechArt.DrawIoSharing.WebApp.Models;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    [Authorize(Roles = nameof(DefaultRole.Admin))]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;


        public AuthorizationController(IAuthorizationService authorizationService, IUserService userService)
        {
            _authorizationService = authorizationService;
            _userService = userService;
        }


        public async Task<ActionResult> Admin()
        {
            var users = await _userService.GetAllAsync();
            var usersWithRoles = new Dictionary<User, IList<DefaultRole>>();
            foreach (var user in users)
            {
                usersWithRoles.Add(user, await _authorizationService.GetRolesAsync(user.Id));
            }
            ViewBag.UsersWithRoles = usersWithRoles;
            return View();
        }

        public async Task<ActionResult> UserSettings(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            var userRoles = await _authorizationService.GetRolesAsync(userId);
            var userSettingsModel = new UserSettingsModel
            {
                GetModel = new KeyValuePair<User, IList<DefaultRole>>(user, userRoles),
                PostModel = new UserSettingsPostModel()
            };

            return View(userSettingsModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> UserSettings(UserSettingsModel model)
        {
            var userId = model.PostModel.UserId;
            var roles = await _authorizationService.GetRolesAsync(userId);
            if (model.PostModel.IsApprovedStatusChanged)
            {
                if (roles.Contains(DefaultRole.ApprovedUser))
                {
                    await _authorizationService.DisapproveAsync(userId);
                }
                else
                {
                    await _authorizationService.ApproveAsync(userId);
                }
            }
            if (model.PostModel.IsRightsStatusChanged)
            {
                if (roles.Contains(DefaultRole.Admin))
                {
                    await _authorizationService.RemoveAdminAsync(userId);
                }
                else
                {
                    await _authorizationService.MakeAdminAsync(userId);
                }
            }
            if (model.PostModel.IsBanStatusChanged)
            {
                if (roles.Contains(DefaultRole.BannedUser))
                {
                    await _authorizationService.UnbanAsync(userId);
                }
                else
                {
                    await _authorizationService.BanAsync(userId);
                }
            }

            return RedirectToAction("Admin", "Authorization");
        }
    }
}