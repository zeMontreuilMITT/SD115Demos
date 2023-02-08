namespace SD115Demos.Models
{
    public class Course
    {
        private int _courseId;
        public int CourseId { get { return _courseId; } }

        public string Title { get; set; }

        public HashSet<Student> Students = new HashSet<Student>();

        public Course(int courseId, string title)
        {
            _courseId = courseId;
            Title = title;
        }

        public Course()
        {

        }
    }
}
