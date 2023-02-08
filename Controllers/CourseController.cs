using Microsoft.AspNetCore.Mvc;
using SD115Demos.Data;
using SD115Demos.Models;

namespace SD115Demos.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View(FakeContext.Courses);
        }

        public IActionResult Details(int courseid)
        {
            Course course = FakeContext.Courses.FirstOrDefault(c => c.CourseId == courseid);
            return View(course);
        }

        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, int times)
        { 
            FakeContext.CreateCourse(Title);
            return RedirectToAction("Index");
        }
    }
}
