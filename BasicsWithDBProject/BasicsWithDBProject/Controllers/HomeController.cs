using BasicsWithDBProject.Data;
using BasicsWithDBProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BasicsWithDBProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly Db2311C3Context _context;

        public HomeController(Db2311C3Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

      

        public IActionResult Privacy()
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
