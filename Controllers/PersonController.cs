using Microsoft.AspNetCore.Mvc;

namespace SD115Demos.Controllers
{
    public class PersonController: Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Me(string name, string number)
        {
            ViewBag.Name = name;

            ViewBag.Number = Int32.Parse(number);
            return View();
        }
    }
}
