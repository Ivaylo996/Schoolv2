namespace Schoolv2
{
    public class Course : IEquatable<Course?>
    {
        private string _courseName;
        private List<Student> _studentsInCourse = new List<Student>();

        public Course(string name)
        {
            CourseName = name;
            StudentsInCourse = new List<Student>();
        }

        public Course(string name, List<Student> students) : this(name)
        {
            CourseName = name;
            StudentsInCourse = students;
        }

        public List<Student> StudentsInCourse
        {
            get 
            { 
                return _studentsInCourse; 
            }
            set
            {
                if (value.Count >= 30)
                {
                    throw new Exception("Too much students for the course!");
                }
                else
                {
                    _studentsInCourse = value;
                }
            }
        }

        public string CourseName
        {
            get 
            { 
                return _courseName; 
            }
            set
            {
                if (!value.Equals(""))
                {
                    _courseName = value;
                }
                else
                {
                    throw new Exception("Course Name cannot be null");
                }
            }
        }

        public void AddStudentToCourse(Student stu)
        {

            if (_studentsInCourse.Count >= 29)
            {
                throw new Exception("This course is full!");
            }
            else
            {
                if (!_studentsInCourse.Contains(stu))
                {
                    _studentsInCourse.Add(stu);
                }
                else
                {
                    throw new Exception("This student is already in this course");
                }
            }
        }

        public void AddManyStudentsToCourse(List<Student> newStudents)
        {
            foreach (Student student in newStudents)
            {
                if (!_studentsInCourse.Contains(student))
                {
                    AddStudentToCourse(student);
                }
                else
                {
                    throw new Exception($"{student.Name}, {student.UniqueNumber} already exists");
                }
            }
        }

        public void RemoveStudentFromCourse(Student stu)
        {
            if (!_studentsInCourse.Contains(stu))
            {
                throw new Exception("The student is not found in this particular course");
            }
            else
            {
                _studentsInCourse.Remove(stu);
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Course);
        }

        public bool Equals(Course? other)
        {
            return other != null &&
            _courseName == other._courseName;
        }
    }
}
