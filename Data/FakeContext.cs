using SD115Demos.Models;

namespace SD115Demos.Data
{
    public static class FakeContext
    {
        public static HashSet<Student> Students = new HashSet<Student>();
        public static HashSet<Course> Courses = new HashSet<Course>();

        private static int _idCounter = 1;

        public static void CreateCourse(string title)
        {
            Courses.Add(new Course(_idCounter++, title));
        }

        public static Student CreateStudent(string name, int age)
        {
            Student newStudent = new Student(_idCounter++, name, age);

            Students.Add(newStudent);
            return newStudent;
        }

        private static void _seedMethod()
        {
            // "Seed Method"
            Student firstStudent = new Student(_idCounter++, "Bob Burger", 29);
            Student secondStudent = new Student(_idCounter++, "Linda Burger", 32);
            Student thirdStudent = new Student(_idCounter++, "Gene Burger", 78);

            Course filledCourse = new Course(_idCounter++, "Advanced Burgers");
            Course secondCourse = new Course(_idCounter++, "How to Be Great at Football");

            filledCourse.Students.Add(firstStudent);
            filledCourse.Students.Add(secondStudent);

            firstStudent.EnrolledCourse = filledCourse;
            secondStudent.EnrolledCourse = filledCourse;

            Courses.Add(filledCourse);
            Courses.Add(secondCourse);
            Students.Add(firstStudent);
            Students.Add(secondStudent);
            Students.Add(thirdStudent);
        }

        static FakeContext()
        {
            _seedMethod();
        }
    }
}
