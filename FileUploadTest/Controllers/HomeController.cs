using FileUploadTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileUploadTest.Controllers
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
        public IActionResult Upload(FileUploadRequest request)
        {
            if (!ModelState.IsValid) return this.Error();

            // do stuff with request.File here


            return this.Ok(request.File.FileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}