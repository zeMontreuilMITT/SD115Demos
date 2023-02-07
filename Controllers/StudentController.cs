using Microsoft.AspNetCore.Mvc;
using SD115Demos.Data;
using SD115Demos.Models;
using System.Security.Cryptography.X509Certificates;

namespace SD115Demos.Controllers
{
    public class StudentController : Controller
    {
        // CRUD
        public IActionResult IndexAgeOver20()
        {
            List<Student> students = FakeContext.Students.Where(studentElement =>
            {
                return studentElement.Age > 20;
            }).ToList<Student>();
            return View("Index", students);
        }

        // create an endpoint for viewing all students whose names start with a specific letter/set of letters

        public IActionResult GetWithNameStart(string name)
        {
            List<Student> students = FakeContext.Students.Where(studentEle =>
            {
                return studentEle.StudentName.StartsWith(name);
            }).ToList();

            return View("Index", students);
        }

        public IActionResult Details(int id)
        {
            Student student = FakeContext.Students.First(studentEle => {
                return studentEle.StudentId == id;
            });

            return View(student);
        }

        public IActionResult GetByName(string name)
        {
            Student student = FakeContext.Students.First(s => s.StudentName.StartsWith(name));

            return View("Details", student);
        }


        // Student/GetByName(string name)
        // View should show all the details of the student that has the matching name
    }
}
