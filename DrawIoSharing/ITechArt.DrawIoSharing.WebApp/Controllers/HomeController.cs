using System.Web.Mvc;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private IUnitOfWork _unitOfWork;
        private ILogger _logger;


        public HomeController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.Debug("App runs!");
            return View(_unitOfWork.Repository<User>().GetAll());
        }
    }
}