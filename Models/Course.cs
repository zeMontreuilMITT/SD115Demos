namespace SD115Demos.Models
{
    public class Course
    {
        private int _courseId;
        public int CourseId { get { return _courseId; } }

        private string _title;
        public string Title { get { return _title; } }

        public HashSet<Student> Students = new HashSet<Student>();

        public Course(int courseId, string title)
        {
            _courseId = courseId;
            _title = title;
        }
    }
}
