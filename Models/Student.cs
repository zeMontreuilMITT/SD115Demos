namespace SD115Demos.Models
{
    public class Student
    {
        private readonly int _studentId;
        public int StudentId { get { return _studentId; } }


        private string _studentName;
        public string StudentName { get { return _studentName; }
            set
            {
                if(value.Length < 2 || value.Length > 100)
                {
                    throw new ArgumentException("Student names must be stored between 2 and 100 characters");
                }
                else
                {
                    _studentName = value;
                }
            }
        }



        private int _age;
        public int Age { get { return _age; } }
        private void _setAge(int age)
        {
            if (age < 1)
            {
                throw new ArgumentException("Age must be greater than 0.");
            }
            else
            {
                _age = age;
            }
        }

        public Course EnrolledCourse { get; set; }
        public Student(int studentId, string name, int age)
        {
            _studentId = studentId;
            _studentName = name;
            _setAge(age);
        }

    }
}
