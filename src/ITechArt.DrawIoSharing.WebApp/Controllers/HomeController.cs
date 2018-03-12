using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;


        public HomeController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ViewResult> Index()
        {
            _logger.Debug("App runs!");
            
            var result = await _unitOfWork.GetRepository<User>().GetAllAsync();

            return View(result);
        }
    }
}