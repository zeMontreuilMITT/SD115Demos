using Microsoft.AspNetCore.Mvc;

namespace SD115Demos.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Laptops()
        {
            return View();
        }


        public IActionResult Laptops(int brandId) 
        {
            return View();
        }
    }
}
