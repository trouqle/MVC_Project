using DragDrop2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DragDrop2.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile userfile)
        {
            string filename = userfile.FileName;
            filename = Path.GetFileName(filename);
            
            string uploadfilepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", filename);
            var stream = new FileStream(uploadfilepath, FileMode.Create);
            
            userfile.CopyToAsync(stream);

            ViewBag.message = "File Uploaded Successfully";

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