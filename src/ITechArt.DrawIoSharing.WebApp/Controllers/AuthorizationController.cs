using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.Authorization;
using ITechArt.DrawIoSharing.Foundation.RoleManagement;
using ITechArt.DrawIoSharing.Foundation.UserManagement;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    [Authorize]
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
            var usersWithRoles = new Dictionary<DomainModel.User, IList<DefaultRole>>();
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
            return View(new KeyValuePair<User, IList<DefaultRole>>(user, userRoles));
        }
    }
}