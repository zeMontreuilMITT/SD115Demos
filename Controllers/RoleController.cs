using Microsoft.AspNetCore.Mvc;
using SD115Demos.Models;
using SD115Demos.Models.ViewModels;
using SD115Demos.Data;

namespace SD115Demos.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateRoleVM vm = new CreateRoleVM(Context.Movies, Context.Actors);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create([Bind("ActorId","MovieId","Credit","Pay")] CreateRoleVM vm)
        {
            Actor actor = Context.Actors.First(a => a.Id == Int32.Parse(vm.ActorId));
            Movie movie = Context.Movies.First(m => m.Id == Int32.Parse(vm.MovieId));
            string credit = vm.Credit;
            int pay = vm.Pay;

            // create new role and add to Context/Actor Relationships


            return View();
        }
    }
}
