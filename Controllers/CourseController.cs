using Microsoft.AspNetCore.Mvc;
using SD115Demos.Data;
using SD115Demos.Models;

namespace SD115Demos.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Details(int id)
        {
            Course course = FakeContext.Courses.FirstOrDefault(c => c.CourseId == id);
            return View(course);
        }
    }
}
