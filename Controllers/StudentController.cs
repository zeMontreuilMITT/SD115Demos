using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SD115Demos.Data;
using SD115Demos.Models;
using System.Security.Cryptography.X509Certificates;

namespace SD115Demos.Controllers
{
    public class StudentController : Controller
    {
        // HTTP Get Method
        // Resource/Action
        // Student/AllOver20

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", FakeContext.Students);
        }

        // pass a single student
        public IActionResult AddToCourse(int studentId)
        {
            Student student = FakeContext.Students.FirstOrDefault(s => s.StudentId == studentId);
            if(student == null)
            {
                return NotFound();
            }
            else if (student.EnrolledCourse == null)
            {
                ViewBag.StudentId = studentId;
                return View(FakeContext.Courses);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        
        
        [HttpPost]
        public IActionResult AddToCourse(int courseId, int studentId)
        {
            try
            {
                Student student = FakeContext.Students.First(s => s.StudentId == studentId);
                Course course = FakeContext.Courses.First(c => c.CourseId == courseId);

                student.EnrolledCourse = course;
                course.Students.Add(student);

                return RedirectToAction("Details", "Course", new {courseid = course.CourseId});
            } catch(Exception ex)
            {
                return BadRequest();
            }
            
        }
        

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

            Student student = FakeContext.Students.FirstOrDefault(studentEle => {
                return studentEle.StudentId == id;
            });

            return View(student);
        }

        public IActionResult GetByName(string name)
        {
            Student student = FakeContext.Students.First(s => s.StudentName.StartsWith(name));

            return View("Details", student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string StudentName, int Age)
        {
            Student newStudent = FakeContext.CreateStudent(StudentName, Age);
            return RedirectToAction("Details", new { id = newStudent.StudentId, secondId = 13,  });
        }
    }
}
