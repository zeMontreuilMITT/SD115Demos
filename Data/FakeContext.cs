using SD115Demos.Models;

namespace SD115Demos.Data
{
    public static class FakeContext
    {
        public static HashSet<Student> Students = new HashSet<Student>();
        public static HashSet<Course> Courses = new HashSet<Course>();

        private static int _idCounter = 1;

        static FakeContext()
        {
            // "Seed Method"
            Student firstStudent = new Student(_idCounter++, "Bob Burger", 29);
            Student secondStudent = new Student(_idCounter++, "Linda Burger", 32);

            Course filledCourse = new Course(_idCounter++, "Advanced Burgers");

            filledCourse.Students.Add(firstStudent);
            filledCourse.Students.Add(secondStudent);

            firstStudent.EnrolledCourse = filledCourse;
            secondStudent.EnrolledCourse = filledCourse;

            Courses.Add(filledCourse);
            Students.Add(firstStudent);
            Students.Add(secondStudent);
        }
    }
}
