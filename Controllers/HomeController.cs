using Microsoft.AspNetCore.Mvc;
using SD115Demos.Data;
using SD115Demos.Models;
using SD115Demos.Models.ViewModels;
using System.Diagnostics;

namespace SD115Demos.Controllers
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
            MoviesAndActors vm = new MoviesAndActors(Context.Movies, Context.Actors, "This is a web app about movies and actors.");
            return View(vm);
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