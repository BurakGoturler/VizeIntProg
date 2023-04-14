using burakgoturler21660110043.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace burakgoturler21660110043.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Hakkinda()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Uygulama içerisinde herhangi bir “Controller” sınıfında adından farklı bir “View” çağıran
        // ve doğru şekilde çalışan bir “Action” olmalıdır. (15 puan)
        public IActionResult FarkliAd()
        {
            return View("farkliview");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}