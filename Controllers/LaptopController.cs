using Microsoft.AspNetCore.Mvc;
using SD115Demos.Models;
using SD115Demos.Data;
using System.Text.RegularExpressions;
using SD115Demos.Models.ViewModel;

namespace SD115Demos.Controllers
{
    public class LaptopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TwoMostExpensive()
        {
            HashSet<Laptop> laptops = Database.Laptops.OrderByDescending(l => l.Price).Take(2).ToHashSet();
            ViewBag.PageTitle = "Two Most Expensive Laptops";
            return View("List", laptops);
        }
        public IActionResult ThreeLeastExpensive()
        {
            HashSet<Laptop> laptops = Database.Laptops.OrderBy(l => l.Price).Take(3).ToHashSet();
            ViewBag.PageTitle = "Three Least Expensive Laptops";
            return View("List", laptops);
        }
        public IActionResult LaptopsByType()
        {
            HashSet<IGrouping<LaptopType, Laptop>> typeGroups = Database.Laptops.GroupBy(l => l.Type).ToHashSet();

            return View("GroupList", typeGroups);
        }


        // === AFFORDABLE GET
        [HttpGet]
        public IActionResult Affordable()
        {
            return View(new AffordableViewModel());
        }

        // === AFFORDABLE POST
        [HttpPost]
        public IActionResult Affordable(decimal Budget)
        {
            HashSet<Laptop> affordableLaptops = Database.Laptops.Where(l => l.Price <= Budget).ToHashSet();

            AffordableViewModel vm = new AffordableViewModel(affordableLaptops, (int)Budget);
            return View(vm);
        }


        [HttpGet]
        public IActionResult CompareLaptops()
        {
            return View(new CompareLaptopsViewModel(Database.Laptops));
        }

        [HttpPost]
        public IActionResult CompareLaptops([Bind("FirstLaptopId,SecondLaptopId")] CompareLaptopsViewModel vm)
        {
            try
            {
                vm.FirstLaptop = Database.Laptops.First(l => l.Id == vm.FirstLaptopId);

                vm.SecondLaptop = Database.Laptops.First(l => l.Id == vm.SecondLaptopId);

                vm.PopulateLaptopItems(Database.Laptops);
                return View(vm);
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
