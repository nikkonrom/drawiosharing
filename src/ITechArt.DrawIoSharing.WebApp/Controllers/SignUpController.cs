using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation;
using ITechArt.DrawIoSharing.Foundation.UserService;
using ITechArt.DrawIoSharing.WebApp.Models;
using Microsoft.AspNet.Identity.Owin;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class SignUpController : Controller
    {
        private IUserService<User> UserService => HttpContext.GetOwinContext().GetUserManager<UserService>();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var id = (new Random()).Next().GetHashCode().ToString();
                var user = new User { Id = id,  UserName = model.Name, Email = model.Email };
                var result = await UserService.CreateUserAsync(user, model.Password);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                AddErrorsFromResult(result);
            }

            return View(model);
        }

        private void AddErrorsFromResult(OperationResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}