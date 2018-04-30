using System.Threading.Tasks;
using System.Web.Mvc;
using ITechArt.DrawIoSharing.Foundation.Authorization;
using ITechArt.DrawIoSharing.Foundation.UserManagement;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    [Authorize]
    public class AuthorizationController : Controller
    {
        private IAuthorizationService _authorizationService;
        private readonly IUserService _userService;


        public AuthorizationController(IAuthorizationService authorizationService, IUserService userService)
        {
            _authorizationService = authorizationService;
            _userService = userService;
        }


        public async Task<ActionResult> Admin()
        {
            var users = await _userService.GetAllUsersAsync();
            ViewBag.Users = users;
            return View();
        }
    }
}