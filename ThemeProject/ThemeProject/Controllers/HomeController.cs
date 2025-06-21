using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThemeProject.Models;

namespace ThemeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //var heading = "Ultimate Welding and Quality Metal Solutions";

            ViewBag.heading = "Ultimate Welding and Quality Metal Solutions";

            ViewData["paragraph"] = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur tellus augue,\r\n                    iaculis id elit eget, ultrices pulvinar tortor. Quisque vel lorem porttitor, malesuada arcu\r\n                    quis, fringilla risus. Pellentesque eu consequat augue.";


            ViewData["image"] = "img/about.jpg";

            TempData["heading2"] = "Certified Expert & Team";
            TempData.Keep();

            return View();
        }
        public IActionResult About()
        {
            TempData.Keep("heading2");
            return View();
        }
        public IActionResult Contact()
        {
            TempData.Keep("heading2");
            return View();
        }
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
            return View();
        }
        public IActionResult Feature()
        {
            return View();
        }
        public IActionResult Page404()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
